using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AgentDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public RequestRepository(AgentDbContext context,Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        public async Task<IEnumerable<RequestTbl?>> GetRequest()
        {
            try
            {
                return await _context.RequestTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public async Task<RequestTbl?> GetRequestAsync(int requestId)
        {
            return await _context.RequestTbl
             .Include(c => c.Agent.AgentName)
             .Include(x => x.Agent.AgentFamily)
             .Include(x => x.TravelTopic)
             .Include(x => x.ApprovedBy)
             .Include(c => c.TravelDate)
             .Include(c => c.TravelTypeId)
             .Include(c => c.RequestStatusId)

             .Where(c => c.RequestId == requestId).FirstOrDefaultAsync();
        }

        public async Task<RequestTbl?> InsertRequest1Async(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.ExecutiveDeviceName = request.ExecutiveDeviceName;
                qtbl.InternetAddressOfTheExecutiveDevice = request.InternetAddressOfTheExecutiveDevice;
                qtbl.DestinationCity = request.DestinationCity;
                qtbl.DestinationCountry = request.DestinationCountry;
                qtbl.FlightPath = request.FlightPath;
                qtbl.TravelDate = request.TravelDate;
                qtbl.TravelTime = request.TravelTime;
                qtbl.TravelTopic = request.TravelTopic;
                qtbl.TravelGoalId = request.TravelGoalId;
                qtbl.JobGoalId = request.JobGoalId;
                qtbl.DeviceNameId = request.DeviceNameId ;
                qtbl.PassportTypeId = request.PassportTypeId;
                qtbl.GetVisa = request.GetVisa;
                qtbl.JointTrip = request.JointTrip;
                qtbl.DateLetter = request.DateLetter;


                await _context.RequestTbl.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }

        }


        public async Task<RequestTbl?> InsertRequest2Async(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.Agent.AgentName= request.Agent.AgentName;
                qtbl.Agent.AgentFamily = request.Agent.AgentFamily;
                qtbl.Agent.AgentFatherName = request.Agent.AgentFatherName;
                qtbl.Agent.BirthCertificateNumber = request.Agent.BirthCertificateNumber;
                qtbl.Agent.NationalCode = request.Agent.NationalCode;
                qtbl.Agent.DateOfBirth = request.Agent.DateOfBirth;
                qtbl.Agent.GenderId = request.Agent.GenderId;
                qtbl.Agent.MaritalStatusId = request.Agent.MaritalStatusId;
                qtbl.Agent.Degree = request.Agent.Degree;
                qtbl.Agent.FieldOfStudy= request.Agent.FieldOfStudy;
                qtbl.Agent.WorkExperience = request.Agent.WorkExperience;
                qtbl.Agent.LanguageId = request.Agent.LanguageId;
                qtbl.Agent.Mobile = request.Agent.Mobile;
                qtbl.Agent.Phone = request.Agent.Phone;
                qtbl.PassportTypeId = request.PassportTypeId;
                qtbl.Agent.Joblocation = request.Agent.Joblocation;
                qtbl.Agent.Position = request.Agent.Position;
                qtbl.EmployeeStatus = request.EmployeeStatus;



                await _context.RequestTbl.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<RequestTbl?> InsertRequest3Async(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.JobGoalId = request.JobGoalId;
                qtbl.PayerCitizenShip = request.PayerCitizenShip;
                qtbl.AmountOfCost = request.AmountOfCost;
                qtbl.PayerFood = request.PayerFood;
                qtbl.CostOfFood = request.CostOfFood;
                qtbl.TickerTypeId = request.TickerTypeId;
                qtbl.AirlineCompany = request.AirlineCompany;
                qtbl.TicketCost = request.TicketCost;
                qtbl.TheCostOfTicket = request.TheCostOfTicket;
                qtbl.RightOfMissionId = request.RightOfMissionId;
                qtbl.LevelRightOfMission = request.LevelRightOfMission;
                qtbl.ExpertRightOfMission = request.ExpertRightOfMission;
                qtbl.RightToEducationCost = request.RightToEducationCost;
                qtbl.RightToEducationId = request.RightToEducationId;
                qtbl.RightOfCommutingCost = request.RightOfCommutingCost;
                qtbl.RightOfCommutingId = request.RightOfCommutingId;
                qtbl.VisaCost = request.VisaCost;
                qtbl.TollAmountCost = request.TollAmountCost;
                qtbl.TollAmountId = request.TollAmountId;
                qtbl.PaymentFromBank = request.PaymentFromBank;


                await _context.RequestTbl.AddAsync(request);
                await _context.SaveChangesAsync();

                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }

        }

        public async Task<RequestTbl?> InsertRequest4Async(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.ImportantTravel = request.ImportantTravel;
                qtbl.MissionAchievementRecords= request.MissionAchievementRecords;
                qtbl.SummaryInvitation = request.SummaryInvitation;
                qtbl.ForeignTravelSummary = request.ForeignTravelSummary;
                qtbl.ReferenceDeviceAgreement = request.ReferenceDeviceAgreement;
                qtbl.ResistanceEconomyTravel = request.ResistanceEconomyTravel;



                await _context.RequestTbl.AddAsync(request);
                await _context.SaveChangesAsync();


                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);
                if (request.RequestStatusId == 1)
                {
                    //qtbl.ConfirmDate = date;

                }
                var Req = await _context.RequestTbl.AddAsync(qtbl);
                await _context.SaveChangesAsync();

                //var data = await _agentRepository.GetAgentAsync(request.AgentId);
                //data.RequestId = qtbl.RequestId;

                //await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task RemoveRequestAsync(int requestId)
        {
            var data = _context.RequestTbl.Find(requestId);
            _context.RequestTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RequestExistsAsync(int RequestId)
        {
            return await _context.RequestTbl.AnyAsync(f => f.RequestId == RequestId);
        }


        public async Task<RequestTbl?> RejectRequest(int requestId)
        {
            return await _context.RequestTbl
            .Include(x => x.ExecutiveDeviceName)
            .Include(x => x.InternetAddressOfTheExecutiveDevice)
            .Include(x => x.DestinationCity)
            .Include(x => x.DestinationCountry)
            .Include(c => c.FlightPath)
            .Include(c => c.TravelDate)
            .Include(c => c.TravelTime)
            .Include(c => c.TravelTopic)
            .Include(c => c.TravelGoalId)
            .Include(c => c.JobGoalId)
            .Include(c => c.DeviceNameId)
            .Include(c => c.PassportTypeId)
            .Include(c => c.GetVisa)
            .Include(c => c.JointTrip)
            .Include(c => c.DateLetter)
            .Include(c => c.Agent.AgentName)
            .Include(c => c.Agent.AgentFamily)
            .Include(c => c.Agent.AgentName)
            .Include(c => c.Agent.AgentFamily)
            .Include(c => c.Agent.AgentFatherName)
            .Include(c => c.Agent.BirthCertificateDate)
            .Include(c => c.Agent.BirthCertificateNumber)
            .Include(c => c.Agent.NationalCode)
            .Include(c => c.Agent.DateOfBirth)
            .Include(c => c.Agent.GenderId)
            .Include(c => c.Agent.MaritalStatusId)
            .Include(c => c.Agent.Degree)
            .Include(c => c.Agent.FieldOfStudy)
            .Include(c => c.Agent.WorkExperience)
            .Include(c => c.Agent.LanguageId)
            .Include(c => c.Agent.Mobile)
            .Include(c => c.Agent.Phone)
            .Include(c => c.PassportTypeId)
            .Include(c => c.Agent.Joblocation)
            .Include(c => c.Agent.Position)
            .Include(c => c.EmployeeStatus)
            .Include(c => c.JobGoal)
            .Include(c => c.PayerCitizenShip)
            .Include(c => c.AmountOfCost)
            .Include(c => c.PayerFood)
            .Include(c => c.CostOfFood)
            .Include(c => c.TickerTypeId)
            .Include(c => c.AirlineCompany)
            .Include(c => c.TicketCost)
            .Include(c => c.TheCostOfTicket)
            .Include(c => c.RightOfMission)
            .Include(c => c.LevelRightOfMission)
            .Include(c => c.ExpertRightOfMission)
            .Include(c => c.RightToEducationCost)
            .Include(c => c.RightToEducationId)
            .Include(c => c.RightOfCommutingCost)
            .Include(c => c.RightOfCommutingId)
            .Include(c => c.VisaCost)
            .Include(c => c.TollAmountCost)
            .Include(c => c.TollAmountId)
            .Include(c => c.PaymentFromBank)
            .Include(c => c.ImportantTravel)
            .Include(c => c.MissionAchievementRecords)
            .Include(c => c.SummaryInvitation)
            .Include(c => c.ForeignTravelSummary)
            .Include(c => c.ReferenceDeviceAgreement)
            .Include(c => c.ResistanceEconomyTravel)



            .Where(c => c.RequestId == requestId).FirstOrDefaultAsync();
        }
        public async Task<RequestDto?> UpdateRequestAsync(RequestDto request)
        {
            try
            {
                var req = await GetRequestAsync(request.RequestId);
                req.TravelDate = request.TravelDate;
                



                await _context.SaveChangesAsync();
                return request;
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<RequestStatusTbl>> GetRequestStatusAsync()
        {
            return await _context.RequestStatusTbl.ToListAsync();
        }

        //public async Task<RuleTbl?> GetRuleAsync(int RuleId)
        //{
        //    return await _context.RuleTbl.Where(f => f.RuleId == RuleId).FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<RuleTbl?>> GetRule()
        {
            try
            {
                return await _context.RuleTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<RequestTbl?> AcceptRequest(int requestId)
        {
            
             return await _context.RequestTbl
            .Include(x => x.ExecutiveDeviceName)
            .Include(x => x.InternetAddressOfTheExecutiveDevice)
            .Include(x => x.DestinationCity)
            .Include(x => x.DestinationCountry)
            .Include(c => c.FlightPath)
            .Include(c => c.TravelDate)
            .Include(c => c.TravelTime)
            .Include(c => c.TravelTopic)
            .Include(c => c.TravelGoalId)
            .Include(c => c.JobGoalId)
            .Include(c => c.DeviceNameId)
            .Include(c => c.PassportTypeId)
            .Include(c => c.GetVisa)
            .Include(c => c.JointTrip)
            .Include(c => c.DateLetter)
            .Include(c => c.Agent.AgentName)
            .Include(c => c.Agent.AgentFamily)
            .Include(c => c.Agent.AgentName)
            .Include(c => c.Agent.AgentFamily)
            .Include(c => c.Agent.AgentFatherName)
            .Include(c => c.Agent.BirthCertificateDate)
            .Include(c => c.Agent.BirthCertificateNumber)
            .Include(c => c.Agent.NationalCode)
            .Include(c => c.Agent.DateOfBirth)
            .Include(c => c.Agent.GenderId)
            .Include(c => c.Agent.MaritalStatusId)
            .Include(c => c.Agent.Degree)
            .Include(c => c.Agent.FieldOfStudy)
            .Include(c => c.Agent.WorkExperience)
            .Include(c => c.Agent.LanguageId)
            .Include(c => c.Agent.Mobile)
            .Include(c => c.Agent.Phone)
            .Include(c => c.PassportTypeId)
            .Include(c => c.Agent.Joblocation)
            .Include(c => c.Agent.Position)
            .Include(c => c.EmployeeStatus)
            .Include(c => c.JobGoal)
            .Include(c => c.PayerCitizenShip)
            .Include(c => c.AmountOfCost)
            .Include(c => c.PayerFood)
            .Include(c => c.CostOfFood)
            .Include(c => c.TickerTypeId)
            .Include(c => c.AirlineCompany)
            .Include(c => c.TicketCost)
            .Include(c => c.TheCostOfTicket)
            .Include(c => c.RightOfMission)
            .Include(c => c.LevelRightOfMission)
            .Include(c => c.ExpertRightOfMission)
            .Include(c => c.RightToEducationCost)
            .Include(c => c.RightToEducationId)
            .Include(c => c.RightOfCommutingCost)
            .Include(c => c.RightOfCommutingId)
            .Include(c => c.VisaCost)
            .Include(c => c.TollAmountCost)
            .Include(c => c.TollAmountId)
            .Include(c => c.PaymentFromBank)
            .Include(c => c.ImportantTravel)
            .Include(c => c.MissionAchievementRecords)
            .Include(c => c.SummaryInvitation)
            .Include(c => c.ForeignTravelSummary)
            .Include(c => c.ReferenceDeviceAgreement)
            .Include(c => c.ResistanceEconomyTravel)



            .Where(c => c.RequestId == requestId).FirstOrDefaultAsync();
          
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


        #region Request Status
        public async Task<IEnumerable<RequestStatusTbl>> RequestStatusAsync()
        {
            return await _context.RequestStatusTbl.ToListAsync();
        }
        #endregion

        #region Travel Goals Type
        public async Task<IEnumerable<TravelGoalsTypeTbl>> TravelGoalsTypeAsync()
        {
            return await _context.TravelGoalsTypeTbl.ToListAsync();
        }
        #endregion

        #region Job Goals Type
        public async Task<IEnumerable<JobGoalsTypeTbl>> JobGoalsTypeAsync()
        {
            return await _context.JobGoalsTypeTbl.ToListAsync();
        }
        #endregion

        #region Device Name type
        public async Task<IEnumerable<DeviceNameItypeTbl>> DeviceNametypeAsync()
        {
            return await _context.DeviceNameItypeTbl.ToListAsync();
        }
        #endregion

        #region Passport Type
        public async Task<IEnumerable<PassportTbl>> PassportTypeAsync()
        {
            return await _context.PassportTbl.ToListAsync();
        }
        #endregion

        #region Right Of Mission
        public async Task<IEnumerable<RightOfMissionTbl>> RightOfMissionAsync()
        {
            return await _context.RightOfMissionTbl.ToListAsync();
        }
        #endregion

        #region Right Of Commuting Type
        public async Task<IEnumerable<RightOfCommutingTypeTbl>> RightOfCommutingTypeAsync()
        {
            return await _context.RightOfCommutingTypeTbl.ToListAsync();
        }
        #endregion

        #region Right To Education
        public async Task<IEnumerable<RightToEducationTbl>> RightToEducationAsync()
        {
            return await _context.RightToEducationTbl.ToListAsync();
        }


        #endregion

        #region File


        public async Task PostFileAsync(FileUploadModel fileData)
        //public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    FileId = 0,
                    FileName = fileData.FileDetails.FileName,
                };
                var uniqueFileName = GetUniqueFileName(fileData.FileDetails.FileName);
                //var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                var filePath = Path.Combine(uploads, uniqueFileName);

                //using (var stream = System.IO.File.Create(filePath))
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileData.FileDetails.CopyTo(new FileStream(filePath, FileMode.Create));
                    //fileDetails.FileData = stream.ToArray();
                }
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);
                //fileDetails.Date = date;

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
                        //fileDetails.FileData = stream.ToArray();
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

                //var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                //await CopyStream(content, path);
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


    }
}
