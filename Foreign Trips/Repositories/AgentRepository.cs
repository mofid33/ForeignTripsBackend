using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System;
using System.Reflection.Metadata.Ecma335;
using Azure.Core;
using Foreign_Trips.Utility;
using ShenaseMeliBac.Profiles;
using AutoMapper;
using NPOI.SS.Formula.Functions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Foreign_Trips.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AgentDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public AgentRepository(AgentDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> AgentExistsAsync(long agentId)
        {
            
                return await _context.AgentTbl.AnyAsync(f => f.AgentId == agentId);
            
        }

            public async Task<AgentTbl?> GetAgentAsync(long agentId)
        {
            try
            {
                return await _context.AgentTbl.Where(f => f.AgentId == agentId)
                    .Include(t => t.Position)
                    .Include(t => t.AgentStatus)
                    .Include(t => t.SubCategory)

                    .FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<IEnumerable<SubCategoryTbl?>> GetSubCategory()
        {
            try
            {
                return await _context.SubCategoryTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<IEnumerable<PositionTypeTbl?>> GetPosition()
        {
            try
            {
                return await _context.PositionTypeTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<IEnumerable<TypeOfEmploymentTbl?>> GetTypeEmployment()
        {
            try
            {
                return await _context.TypeOfEmploymentTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<AgentPageDto> GetAgent(int page, string search)
        {
            try
            {
                var agents= await _context.AgentTbl
                .Include(t => t.Position)
                .Include(t => t.AgentStatus)
                .Include(t => t.LoginTbls)
                .Include(t => t.City)
                .Where(t=>(search!="")&&(t.AgentName==search||t.AgentFamily==search))


                    .ToListAsync();
                var ss= await PaginatedList<AgentTbl>.CreateAsync(agents, page);
                return new AgentPageDto
                {
                    Count = agents.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
      
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<AgentDto> InsertAgentAsync(AgentDto agent)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(agent.Password.ToString(), out passwordHash, out passwordSalt);
                AgentTbl data = new AgentTbl();
                data.CityId = agent.CityId;
                data.NationalCode = agent.NationalCode;
                data.DateOfBirth = agent.DateOfBirth;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.Address = agent.Address;
                data.SubCategoryId= agent.SubCategoryId;
                data.Subset = agent.Subset;
                data.TypeOfEmploymentId = agent.TypeOfEmploymentId;
                data.PositionId = agent.PositionId;
                data.Password = passwordHash;
                data.PasswordSalt = passwordSalt;
                data.GenderId = agent.GenderId!=0 ? agent.GenderId:2;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                data.RegisterTime = DateTime.Now.ToShortTimeString();
                data.RegisterDate = date;

                await _context.AgentTbl.AddAsync(data);
                await _context.SaveChangesAsync();
                return agent;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<AgentTbl?> UpdateAgentAsync(AgentTbl agent)
        {
            try
            {
                var data = await GetAgentAsync(agent.AgentId);
              
           
                data.Phone = agent.Phone;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.Address = agent.Address;
                data.SubCategoryId = agent.SubCategoryId;
                data.Subset = agent.Subset;
                data.TypeOfEmploymentId = agent.TypeOfEmploymentId;
                data.PositionId = agent.PositionId;
                //data.Password = agent.Password;

                if (agent.Password != null)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(agent.Password.ToString(), out passwordHash, out passwordSalt);
                } 

                await _context.SaveChangesAsync();
                return agent;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }



        public async Task DeleteAgent(int agentId)
        {
           
                var data = _context.AgentTbl.Find(agentId);
                _context.AgentTbl.Remove(data);

                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryTbl>> GetCountriesAcync()
        {
            try
            {
                return await _context.CountryTbl.AsNoTracking().ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<CityTbl>> GetCitiesAcync(int? countryId)
        {
            try
            {
                return await _context.CityTbl
                 .AsNoTracking()
                 .Where(c => c.CountryId == countryId).ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        #region postCode
        public async Task<string> GetAddress(AgentTbl model)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://rsb.iran.gov.ir/gsbServices/TokenPost");
                request.Headers.Add("Authorization", "Basic ZG1scl9yc2I6S0ByQHJzYjEyMw==");

                byte[] bytes;
                var requestXml = "grant_type=password";
                bytes = Encoding.UTF8.GetBytes(requestXml);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                Stream requestStream = await request.GetRequestStreamAsync();
                await requestStream.WriteAsync(bytes);
                requestStream.Close();
                var response = await request.GetResponseAsync();

                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                JObject joResponse = JObject.Parse(responseStr);
                string access = joResponse.First.First.ToString();
                //JObject ojObject = (JObject)joResponse["access_token"];
                //JArray array = (JArray)ojObject["chats"];
                //int id = Convert.ToInt32(array[0].toString());

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("https://rsb.iran.gov.ir/gsbServices/AddressStringByPostcode");
                request2.Headers.Add("Authorization", "Basic ZG1scl9yc2I6S0ByQHJzYjEyMw==");
                request2.ContentType = "application/json; charset=utf-8";
                request2.Method = "POST";
                request2.Headers.Add("token", access);
                byte[] bytes2;
                Random rnd = new Random();
                int num = rnd.Next(1, 1000);
                string json = "{\"ClientBatchID\":\"" + num + "\"," +
                            "\"Postcodes\":[{\"PostCode\":\"\"" + model.PostalCode + "\"\"}]}";


                using (var streamWriter = new StreamWriter(request2.GetRequestStream()))
                {
                    PostCodeModel product = new PostCodeModel();
                    PostCodes codes = new PostCodes();
                    codes.PostCode = model.PostalCode;
                    product.ClientBatchID = num;
                    List<PostCodes> postCodes = new List<PostCodes>();
                    postCodes.Add(codes);
                    product.Postcodes = postCodes;

                    string output = JsonConvert.SerializeObject(product);
                    //string output = JsonConvert.SerializeObject({
                    //    user = "Foo",
                    //    password = "Baz"
                    //});

                    streamWriter.Write(output);
                }
                string id = "";
                var httpResponse = request2.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject joResponse2 = JObject.Parse(result);
                    JArray array = (JArray)joResponse2["Data"];
                    JObject joResponse3 = JObject.Parse(array.First.ToString());
                    JObject joResponse4 = JObject.Parse(joResponse3["Result"].ToString());

                    id = joResponse4["Value"].ToString();
                }
                //string access2 = joResponse2.First.First.ToString();
                return id;

            }
            catch (System.Exception e)
            {
                return null;
            }

        }
        #endregion


        

        public async Task UpdatePassAgentAsync(AgentTbl agent, long agentId)
        {
            try
            {
                var data = await GetAgentAsync(agentId);
                data.Password = agent.Password;
                await _context.SaveChangesAsync();


            }
            catch (System.Exception e)
            {
            }
        }

        public async Task SuspendAgentAsync(long agentId)
        {
            try
            {
                var data = await GetAgentAsync(agentId);
                data.AgentStatus.AgentStatusId = 5;


                await _context.SaveChangesAsync();

            }
            catch (System.Exception e)
            {
            }

        }



        #region AgentStatus
        public async Task<IEnumerable<AgentStatusTbl>> GetAgentStatusAsync()
        {
            return await _context.AgentStatusTbl.ToListAsync();
        }
        #endregion

        #region TypeOfMission
        public async Task<IEnumerable<TypeOfMissionTbl>> GetTypeOfMissionTblAsync()
        {
            return await _context.TypeOfMissionTbl.ToListAsync();
        }
        #endregion 

        #region TypeOfEmployment
        public async  Task<IEnumerable<TypeOfEmploymentTbl>> TypeOfEmploymentTblAsync()
        {
            return await _context.TypeOfEmploymentTbl.ToListAsync();
        }
        #endregion

        #region PositionType
        public async Task<IEnumerable<PositionTypeTbl>> PositionTypeTblAsync()
        {
            return await _context.PositionTypeTbl.ToListAsync();
        }
        #endregion

        #region Marital Status
        public async Task<IEnumerable<MaritalStatusTbl>> MaritalStatusTblAsync()
        {
            return await _context.MaritalStatusTbl.ToListAsync();
        }
        #endregion

        #region Language Type
        public async Task<IEnumerable<LanguageTypeTbl>> LanguageTypeAsync()
        {
            return await _context.LanguageType.ToListAsync();
        }

        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
