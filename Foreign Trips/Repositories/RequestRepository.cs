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

        public RequestRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
           
        }

        public async Task<IEnumerable<RequestTbl?>> GetRequest()
        {
            return await _context.RequestTbl
             .Include(c => c.Agent)
             .ToListAsync();
        }
        public async Task<RequestTbl?> GetRequestAsync(int requestId)
        {
            return await _context.RequestTbl
             .Include(c => c.Agent)

             .Where(c => c.RequestId == requestId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RequestEmployeeTbl?>> GetRequestEmployee()
        {
            try
            {

                return await _context.RequestEmployeeTbl.ToListAsync();
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


        public async Task<RequestTbl?> UpdateRequest2Async(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
               
                qtbl.AgentId = request.AgentId;
                qtbl.EmployeeStatus = request.EmployeeStatus;



               
                await _context.SaveChangesAsync();

                return request;


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


                await _context.SaveChangesAsync();

                return request;


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
                RequestTbl qtbl = new RequestTbl();
                qtbl.ImportantTravel = request.ImportantTravel;
                qtbl.MissionAchievementRecords= request.MissionAchievementRecords;
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
            return await _context.RequestTbl
            
            .Include(c => c.Agent)
            .Include(c => c.RequestStatusId)


            .FirstOrDefaultAsync();
        }

        public async Task<RequestTbl?> AcceptRequest(RequestTbl request)
        {
            try
            {
                var data = await GetNewRequest(request.RequestId);
                data.RequestStatusId = 1;
                await _context.SaveChangesAsync();
                return request;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<RequestTbl?> RejectRequest(RequestTbl request)
        {
            try
            {
               var data = await GetNewRequest(request.RequestId);
               data.RequestStatusId = 2;
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
