﻿using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class SupervisorRepository : ISupervisorRepository

    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;

        public SupervisorRepository(AgentDbContext context, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ??
        throw new ArgumentNullException(nameof(agentRepository));

        }
       

        public async Task<IEnumerable<SupervisorTbl?>> GetSupervisor()
        {
            try
            {
                return await _context.SupervisorTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<SupervisorTbl?> GetSupervisorAsync(int supervisorId)
        {
            return await _context.SupervisorTbl.Where(c => c.SupervisorId == supervisorId).FirstOrDefaultAsync();
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<SupervisorDto> InsertSupervisor(SupervisorDto supervisor)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(supervisor.Password.ToString(), out passwordHash, out passwordSalt);
                SupervisorTbl supervisorTbl = new SupervisorTbl();
                supervisorTbl.SupervisorName = supervisor.SupervisorName;
                supervisorTbl.SupervisorFamily= supervisor.SupervisorFamily;
                supervisorTbl.SupervisorUserName = supervisor.SupervisorUserName;
                supervisorTbl.RegisterDate = supervisor.RegisterDate;
                supervisorTbl.RegisterTime = supervisor.RegisterTime;
                supervisorTbl.Password = passwordHash;
                supervisorTbl.PasswordSalt = passwordSalt;
                


                await _context.SupervisorTbl.AddAsync(supervisorTbl);
                await _context.SaveChangesAsync();
                return supervisor;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

            public async Task<bool> SupervisorExistsAsync(int supervisorId)
        {
            return await _context.SupervisorTbl.AnyAsync(c => c.SupervisorId == supervisorId);
        }

        public async Task<SupervisorTbl?> UpdateSupervisorAsync(SupervisorTbl supervisor)
        {
            try
            {

                var sup = await _context.SupervisorTbl.FindAsync(supervisor.SupervisorId);
                sup.SupervisorName = supervisor.SupervisorName;
                sup.SupervisorFamily = supervisor.SupervisorFamily;
                sup.SupervisorUserName = supervisor.SupervisorUserName;
                sup.Password = supervisor.Password;

                
                await _context.SaveChangesAsync();
                return sup;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

    
        public async Task RemoveSupervisorAsync(int supervisorId)
        {
            var data = _context.SupervisorTbl.Find(supervisorId);
            _context.SupervisorTbl.Remove(data);

            await _context.SaveChangesAsync();

            
        }
    }
}
