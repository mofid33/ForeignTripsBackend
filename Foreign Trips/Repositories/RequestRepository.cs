using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using ShenaseMeliBac.Profiles;

namespace Foreign_Trips.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AgentDbContext _context;

        public RequestRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));

        }

        public async Task<RequestPageDto> GetRequest(int page, int pageSize, string search)
        {
            try
            {
                  var request = await _context.RequestTbl
                 .Include(c => c.Agent)
                 .Include(c => c.RequestStatus)
                 .Include(c => c.InternationalExpert)
                 .Include(c => c.TravelType)
                 .Include(c => c.TypeAccommodation)
                 .Include(c => c.TollAmount)
                 .Include(c => c.City)
                 .Include(c => c.City.Country)
                 .Where(t => (search != "" && search != null) ? (t.Agent.AgentName == search || t.Agent.AgentFamily == search) : t.Agent.AgentName != null)
                 .ToListAsync();

                var ss = await PaginatedList<RequestTbl>.CreateAsync(request, page, pageSize);
                return new RequestPageDto
                {
                    Count = request.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        //LevelRightOfMission  table nadare
        //نوع اقامت کدومه
        public async Task<IEnumerable<RequestTbl?>> GetRequestsExpert(int ExpertId)
        {
            try
            {
                return await _context.RequestTbl
                 .Include(c => c.Agent)
                 .Include(c => c.RequestStatus)
                 .Include(c => c.InternationalExpert)
                 .Include(c => c.TravelType)
                 .Include(c => c.TypeAccommodation)
                 .Include(c => c.TollAmount)
                 

                 .Where(t => t.InternationalExpertId == ExpertId || t.InternationalExpertId == null)
                 .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public async Task<IEnumerable<AllListDto?>> GetAllList()
        {
            try
            {
                var req = await GetRequest();
                AllListDto list = new AllListDto();
                foreach (var allList in req)
                {
                    list.ExecutiveDeviceName = allList.ExecutiveDeviceName;
                    list.InternetAddressOfTheExecutiveDevice = allList.InternetAddressOfTheExecutiveDevice;
                    list.CityId = allList.CityId;
                    list.FlightPath = allList.FlightPath;
                    list.TravelDateStart = allList.TravelDateStart;
                    list.TravalEndDate = allList.TravalEndDate;
                    list.TravelTime = allList.TravelTime;
                    list.TravelTopic = allList.TravelTopic;
                    list.TravelGoalId = allList.TravelGoalId;
                    list.JobGoalId = allList.JobGoalId;
                    list.DeviceName = allList.DeviceName;
                    list.PassportTypeId = allList.PassportTypeId;
                    list.GetVisa = allList.GetVisa;
                    list.JointTrip = allList.JointTrip;
                    list.DateLetter = allList.DateLetter;
                    list.ParticipantId = allList.ParticipantId;
                    //RightOfMissionTbl miss = new RightOfMissionTbl();

                    //foreach (var item in allList.RightOfMissionId.split(','))
                    //{
                    //    miss.RightOfMissionId=
                    //}
                    //list.RightOfMissionId =

                }


                return (IEnumerable<AllListDto?>)list;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }


        public async Task<IEnumerable<RequestTbl?>> GetRequestsAdmin(int AdminId)
        {
            try
            {
                return await _context.RequestTbl
                 .Include(c => c.Agent).Where(t => t.AdminId == AdminId || t.AdminId == null)
                 .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<RequestTbl?>> GetRequestsMainAdmin(int MainAdminId)
        {
            try
            {

                return await _context.RequestTbl
                 .Include(c => c.Agent).Where(t => t.MainAdminId == MainAdminId || t.MainAdminId == null)
                 .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<RequestTbl?> GetRequestAsync(int requestId)
        {
            try
            {
                return await _context.RequestTbl
                 .Include(c => c.Agent)
                 .Include(c => c.RequestStatus)
                 .Include(c => c.InternationalExpert)
                 .Include(c => c.TravelType)
                 .Include(c => c.Participant)
                 .Include(c => c.TypeAccommodation)
                 .Include(c => c.TollAmount)
                 .Include(c => c.City)
                 .Include(c => c.City.Country)
                 .Where(c => c.RequestId == requestId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RequestTbl?>> GetRequestsAgent(int agentId)
        {
            try
            {
                return await _context.RequestTbl
                 .Include(c => c.Agent)
                 .Include(c => c.RequestStatus)

                 .Where(c => c.AgentId == agentId).ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<RequestEmployeeTbl?>> GetRequestEmployeeAsync(int requestId)
        {
            try
            {

                return await _context.RequestEmployeeTbl.Where(x => x.RequestId == requestId)
                    .Include(x => x.MaritalStatus)
                    .Include(x => x.PassPortType)
                    //.Include(x => x.Gender)
                    .Include(x => x.Position)

                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

      
        public async Task<RequestTbl?> InsertRequestAsync(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.ExecutiveDeviceName = request.ExecutiveDeviceName;
                qtbl.InternetAddressOfTheExecutiveDevice = request.InternetAddressOfTheExecutiveDevice;
                qtbl.CityId = request.CityId;
                qtbl.FlightPath = request.FlightPath;
                qtbl.TravelDateStart = request.TravelDateStart;
                qtbl.TravalEndDate = request.TravalEndDate;
                qtbl.TravelTime = request.TravelTime;
                qtbl.TravelTopic = request.TravelTopic;
                qtbl.TravelGoalId = request.TravelGoalId;
                qtbl.JobGoalId = request.JobGoalId;
                qtbl.DeviceName = request.DeviceName;
                qtbl.PassportTypeId = request.PassportTypeId;
                qtbl.GetVisa = request.GetVisa;
                qtbl.JointTrip = request.JointTrip;
                qtbl.DateLetter = request.DateLetter;
                qtbl.ParticipantId = request.ParticipantId;
                qtbl.RequestStatusId = 1;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                qtbl.RegisterTime = DateTime.Now.ToShortTimeString();
                qtbl.RegisterDate = date;

                await _context.RequestTbl.AddAsync(qtbl);
                await _context.SaveChangesAsync();

                return qtbl;


            }

            catch (System.Exception ex)
            {
                return null;

            }

        }

        public async Task<RequestEmployeeTbl?> InsertRequestEmployeeAsync(RequestEmployeeTbl requestemployee)
        {
            try
            {
                await _context.RequestEmployeeTbl.AddAsync(requestemployee);
                await _context.SaveChangesAsync();
                return requestemployee;
            }
            catch (System.Exception ex)
            {
                return null;

            }

        }



        public async Task<RequestTbl?> UpdateRequest3Async(RequestTbl request)
        {
            try
            {
                //فیلد کم داره

                //RequestTbl qtbl = new RequestTbl();
                var qtbl = _context.RequestTbl.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                //qtbl.JobGoalId = request.JobGoalId;
                qtbl.PayerCitizenShip = request.PayerCitizenShip;
                qtbl.AmountOfCost = request.AmountOfCost;
                qtbl.PayerFood = request.PayerFood;
                qtbl.CostOfFood = request.CostOfFood;
                qtbl.TickerTypeId = request.TickerTypeId;
                qtbl.AirlineCompany = request.AirlineCompany;
                qtbl.TicketCost = request.TicketCost;
                qtbl.TheCostOfTicket = request.TheCostOfTicket;
                qtbl.RightOfMissionId = request.RightOfMissionId;
                qtbl.ManagerRightOfMission = request.ManagerRightOfMission;
                qtbl.ExpertRightOfMission = request.ExpertRightOfMission;
                qtbl.GeneralManagerRightOfMission = request.ManagerRightOfMission;
                qtbl.RightToEducationApplicantCost = request.RightToEducationApplicantCost;
                qtbl.RightToEducationInternalDeviceCost = request.RightToEducationInternalDeviceCost;
                qtbl.RightToEducationId = request.RightToEducationId;
                qtbl.RightOfCommutingPersonCost = request.RightOfCommutingPersonCost;
                qtbl.RightOfCommutingInternalDeviceCost = request.RightOfCommutingInternalDeviceCost;
                qtbl.RightOfCommutingExternalCost = request.RightOfCommutingExternalCost;
                qtbl.RightOfCommutingId = request.RightOfCommutingId;
                qtbl.TypeAccommodationId = request.TypeAccommodationId;
                qtbl.VisaCost = request.VisaCost;
                qtbl.TollAmountPersonCost = request.TollAmountPersonCost;
                qtbl.TollAmountDeviceCost = request.TollAmountDeviceCost;
                qtbl.TollAmountId = request.TollAmountId;
                qtbl.PaymentFromBank = request.PaymentFromBank;


                await _context.SaveChangesAsync();

                return qtbl;


            }

            catch (System.Exception ex)
            {
                return null;

            }

        }

        public async Task<RequestTbl?> UpdateRequest4Async(RequestTbl request)
        {
            try
            {
                var qtbl = _context.RequestTbl.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                qtbl.ActivityRecords = request.ActivityRecords;
                qtbl.Results = request.Results;
                qtbl.Discription = request.Discription;
                qtbl.ExternalDeviceNameAndEmail = request.ExternalDeviceNameAndEmail;
                qtbl.DelayReason = request.DelayReason;




                await _context.SaveChangesAsync();


                return qtbl;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<RequestTbl?> UpdateRequest5Async(RequestTbl request)
        {
            try
            {
                var qtbl = _context.RequestTbl.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                qtbl.ImportantTravel = request.ImportantTravel;
                qtbl.MissionAchievementRecords = request.MissionAchievementRecords;
                qtbl.SummaryInvitation = request.SummaryInvitation;
                qtbl.ForeignTravelSummary = request.ForeignTravelSummary;
                qtbl.ReferenceDeviceAgreement = request.ReferenceDeviceAgreement;
                qtbl.ResistanceEconomyTravel = request.ResistanceEconomyTravel;




                await _context.SaveChangesAsync();


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

        public async Task RemoveRequestEmployeeAsync(int employeeId)
        {
            var data = _context.RequestEmployeeTbl.Find(employeeId);
            _context.RequestEmployeeTbl.Remove(data);

            await _context.SaveChangesAsync();
        }



        public async Task<bool> RequestExistsAsync(int RequestId)
        {
            return await _context.RequestTbl.AnyAsync(f => f.RequestId == RequestId);
        }




        //public async Task<RuleTbl?> GetRuleAsync(int RuleId)
        //{
        //    return await _context.RuleTbl.Where(f => f.RuleId == RuleId).FirstOrDefaultAsync();
        //}


        public async Task<RequestTbl?> GetNewRequest(int requestId)
        {
            try
            {
                return await _context.RequestTbl

                .Include(c => c.Agent)
                .Include(c => c.RequestStatus)
                .Where(c => c.RequestId == requestId)
                .FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<RequestTbl?> AcceptRequestExpert(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 2;
                data.InternationalExpertId = request.InternationalExpertId;
                await _context.SaveChangesAsync();
                return data;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<RequestTbl?> RejectRequestExpert(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 3;
                data.RejectRequest = request.RejectRequest;
                await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
        public async Task<RequestTbl?> AcceptReportExpert(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 7;
                await _context.SaveChangesAsync();
                return data;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<RequestTbl?> RejectReportExpert(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 8;
                await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<RequestTbl?> AcceptRequestAdmin(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 4;
                data.AdminId = request.AdminId;
                await _context.SaveChangesAsync();
                return data;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<RequestTbl?> RejectRequestAdmin(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 5;
                data.RejectRequest = request.RejectRequest;
                data.AdminId = request.AdminId;
                await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<RequestTbl?> AcceptRequestMainAdmin(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 4;
                data.MainAdminId = request.MainAdminId;
                await _context.SaveChangesAsync();
                return data;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<RequestTbl?> RejectRequestMainAdmin(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 5;
                data.MainAdminId = request.MainAdminId;
                data.RejectRequest = request.RejectRequest;
                await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
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

        #region Participant
        public async Task<IEnumerable<ParticipantTbl>> ParticipantAsync()
        {
            return await _context.ParticipantTbl.ToListAsync();
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

        #region Toll Amount
        public async Task<IEnumerable<TollAmountTypeTbl>> TollAmountTypeAsync()
        {
            return await _context.TollAmountTypeTbl.ToListAsync();
        }

        #endregion

        #region Travel Type
        public async Task<IEnumerable<TravelTypeTbl>> TravelTypeAsync()
        {
            return await _context.TravelTypeTbl.ToListAsync();
        }

        #endregion


    }
}
