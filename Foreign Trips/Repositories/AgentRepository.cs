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

namespace Foreign_Trips.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AgentDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public AgentRepository(AgentDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        public async Task<bool> AgentExistsAsync(long agentId)
        {
            return await _context.AgentTbl.AnyAsync(f => f.AgentId == agentId);
        }

        public async Task<AgentTbl?> GetAgentAsync(long agentId)
        {
            return await _context.AgentTbl.Where(f => f.AgentId == agentId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AgentTbl>> GetAgent()
        {
            try
            {

                return await _context.AgentTbl.ToListAsync();
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

        public async Task<AgentTbl?> InsertAgentAsync(AgentTbl agent)
        {
            try
            {
                AgentTbl data = new AgentTbl();
                data.CityId = agent.CityId;
                data.TypeOfMissionId= agent.TypeOfMissionId;
                data.SupervisorId =agent.SupervisorId;
                data.PositionId= agent.PositionId; 
                data.AgentStatusId= agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily= agent.AgentFamily;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Address= agent.Address;
                data.Password= agent.Password;
                data.CompanyName = agent.CompanyName;
                data.TypeOfEmployment = agent.TypeOfEmployment;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.RegisterDate= agent.RegisterDate;
                data.RegisterTime= agent.RegisterTime;



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
                data.CityId = agent.CityId;
                data.TypeOfMissionId = agent.TypeOfMissionId;
                data.SupervisorId = agent.SupervisorId;
                data.PositionId = agent.PositionId;
                data.AgentStatusId = agent.AgentStatusId;
                data.AgentName = agent.AgentName;
                data.AgentFamily = agent.AgentFamily;
                data.NationalCode = agent.NationalCode;
                data.Mobile = agent.Mobile;
                data.Phone = agent.Phone;
                data.Address = agent.Address;
                data.Password = agent.Password;
                data.CompanyName = agent.CompanyName;
                data.TypeOfEmployment = agent.TypeOfEmployment;
                data.Email = agent.Email;
                data.PostalCode = agent.PostalCode;
                data.RegisterDate = agent.RegisterDate;
                data.RegisterTime = agent.RegisterTime;


                await _context.SaveChangesAsync();
                return agent;

            }
            catch (System.Exception e)
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

        public async Task<IEnumerable<ProvinceTbl>> GetProvincesAcync()
        {
            return await _context.ProvinceTbl.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<CityTbl>> GetCitiesAcync(int? provinceId)
        {
            return await _context.CityTbl
             .AsNoTracking()
             .Where(c => c.ProvinceId == provinceId).ToListAsync();
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


        #region File

        public async Task PostFileAsync(FileUploadModel fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    FileId = 0,
                    FileName = fileData.FileDetails.FileName,
                };
                var uniqueFileName = GetUniqueFileName(fileData.FileDetails.FileName);

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                var filePath = Path.Combine(uploads, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileData.FileDetails.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);

                var result = _context.FileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();


            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetUniqueFileName(string fileName)
        {

            fileName = Path.GetFileName(fileName);


            return string.Concat(Path.GetFileNameWithoutExtension(fileName)


                                , "_"


                                , Guid.NewGuid().ToString().AsSpan(0, 4)


                                , Path.GetExtension(fileName));


        }

        public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            try
            {
                foreach (FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        FileId = 0,
                        FileName = file.FileDetails.FileName,
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                    }

                    var result = _context.FileDetails.Add(fileDetails);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = _context.FileDetails.Where(x => x.FileId == Id).FirstOrDefaultAsync();

                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        #endregion

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        

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
    }
}
