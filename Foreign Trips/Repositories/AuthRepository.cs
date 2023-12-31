﻿using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Foreign_Trips.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AgentDbContext _context;
        IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration, AgentDbContext context)

        {
            _configuration = configuration;

            _context = context ?? throw new ArgumentException(nameof(context));

        }
        public int GetIDFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            var jti = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            return Convert.ToInt32(jti);
        }

        public LoginDto Login(LoginDto model)
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretForKey"])
                    );
                var signingCredentials = new SigningCredentials(
                    securityKey, SecurityAlgorithms.HmacSha256
                    );
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim(ClaimTypes.Name, model.Username));
                claimsForToken.Add(new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()));
                claimsForToken.Add(new Claim(ClaimTypes.Role, model.Role));

                var jwtSecurityToke = new JwtSecurityToken(
                    _configuration["AppSettings:Issuer"],
                    _configuration["AppSettings:Audience"],
                    //null,null,
                    claimsForToken,
                    DateTime.Now,
                    DateTime.Now.AddHours(1),
                    signingCredentials
                    );

                var tokenToReturn = new JwtSecurityTokenHandler()
                    .WriteToken(jwtSecurityToke);
                //return tokenToReturn;
                return new LoginDto(
                    model.Username,
                    model.Password,
                    model.Role,
                    model.ID,
                    model.Photo,
                    tokenToReturn
                    );

            }
            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<LoginDto> ValidateUserCredentials(string username, string password)
        {
            try
            {
                var mainadmin = await _context.MainAdminTbl
                .Where(f => f.MainAdminUserName == username ).ToListAsync();
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);


                string date = persianDateTime.ToString().Substring(0, 10);

                if (mainadmin.Count > 0)
                {
                    if (!VerifyPasswordHash(password, mainadmin[0].Password, mainadmin[0].PasswordSalt))
                    {
                        return null;

                    }
                    return new LoginDto(
                username,
                password,
                "MainAdmin",
                mainadmin[0].MainAdminId,
                null,
                null
               );
                }

                else
                {
                    var supervisor = await _context.SupervisorTbl
           .Where(f => f.SupervisorUserName == username).ToListAsync();

                    if (supervisor.Count > 0)
                    {
                        if (!VerifyPasswordHash(password, supervisor[0].Password, supervisor[0].PasswordSalt))
                        {
                            return null;

                        }
                        LoginTbl log = new LoginTbl();
                        log.Time = DateTime.Now.ToShortTimeString();

                        log.Date = date;
                        log.SupervisorId = supervisor[0].SupervisorId;
                        await _context.LoginTbl.AddAsync(log);
                        await _context.SaveChangesAsync();
                        return new LoginDto(
                    username,
                    password,
                    "Supervisor",
                   supervisor[0].SupervisorId,
                   null,
                   null);
                    }



                    else
                    {
                        var intexpert = await _context.InternationalExpertTbl
               .Where(f => f.InternationalExpertUserName == username).ToListAsync();

                        if (intexpert.Count > 0)
                        {
                            if (!VerifyPasswordHash(password, intexpert[0].Password, intexpert[0].PasswordSalt))
                            {
                                return null;

                            }
                            LoginTbl log = new LoginTbl();
                            log.Time = DateTime.Now.ToShortTimeString();

                            log.Date = date;
                            log.InternationalExpertId = intexpert[0].InternationalExpertId;
                            await _context.LoginTbl.AddAsync(log);
                            await _context.SaveChangesAsync();
                            return new LoginDto(
                        username,
                        password,
                        "InternationalExpert",
                       intexpert[0].InternationalExpertId,
                        null,
                        null);
                        }

                        else
                        {
                            var intadmin = await _context.InternationalAdminTbl
                   .Where(f => f.AdminUsername == username).ToListAsync();

                            if (intadmin.Count > 0)
                            {
                                if (!VerifyPasswordHash(password, intadmin[0].Password, intadmin[0].PasswordSalt))
                                {
                                    return null;

                                }
                                LoginTbl log = new LoginTbl();
                                log.Time = DateTime.Now.ToShortTimeString();

                                log.Date = date;
                                log.AdminId = intadmin[0].AdminId;
                                await _context.LoginTbl.AddAsync(log);
                                await _context.SaveChangesAsync();
                                return new LoginDto(
                            username,
                            password,
                            "InternationalAdmin",
                           intadmin[0].AdminId,
                           null,
                           null);
                            }


                            else
                            {
                                var agent = await _context.AgentTbl
                       .Where(f => f.NationalCode == username).ToListAsync();

                                if (agent.Count > 0)
                                {
                                    if (!VerifyPasswordHash(password, agent[0].Password, agent[0].PasswordSalt))
                                    {
                                        return null;

                                    }
                                    LoginTbl log = new LoginTbl();
                                    log.Time = DateTime.Now.ToShortTimeString();

                                    log.Date = date;
                                    log.AgentId = agent[0].AgentId;
                                    await _context.LoginTbl.AddAsync(log);
                                    await _context.SaveChangesAsync();
                                    return new LoginDto(
                                username,
                                password,
                                "Agent",
                               agent[0].AgentId,
                               agent[0].Photo,
                               null);
                                }
                                else
                                {
                                    return null;

                                }
                            }
                        }
                    }
                }
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }



            public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
               using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                   {
                      var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                      for (int i = 0; i < computedHash.Length; i++)
                      {
                           if (computedHash[i] != passwordHash[i]) return false;
                      }
                      return true;
                      }
                   }
            public async Task<bool> SaveChangesAsync()
            {
               return (await _context.SaveChangesAsync() > 0);
            }
    }
}
            
            
                

