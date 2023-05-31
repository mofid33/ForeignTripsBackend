using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories

{
    public class RrequestTravelRepository : IRequestTravelRepository
    {
        private readonly AgentDbContext _context;
        private readonly IRequestTravelRepository _requesttravelRepository;
        private readonly IAgentRepository _agentRepository;

        public RrequestTravelRepository(AgentDbContext context, IRequestTravelRepository requesttravelRepository, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _requesttravelRepository = requesttravelRepository ??
               throw new ArgumentNullException(nameof(requesttravelRepository));
            _agentRepository = agentRepository ??
               throw new ArgumentNullException(nameof(agentRepository));
        }
        public async Task<IEnumerable<RequestTravelTbl?>> GetRequestTravel()
        {
            try
            {

                return await _context.RequestTravelTbl.ToListAsync();
            }

            catch (System.Exception ex)
            {
                return null;
            }
        }
        public async Task<RequestTravelTbl?> GetRequestTravelAsync(int RequesttravelId)
        {
            return await _context.RequestTravelTbl.Where(f => f.RequestTravelId == RequesttravelId).FirstOrDefaultAsync();
        }

        public async Task<RequestTravelTbl?> InsertRequestTravelAsync(RequestTravelTbl requesttravel)
        {
            try
            {
                RequestTravelTbl rqtbl = new RequestTravelTbl();
                rqtbl.RequestTravelId = requesttravel.RequestTravelId;
                rqtbl.NameAgent = requesttravel.NameAgent;
                rqtbl.NationalCode = requesttravel.NationalCode;
                rqtbl.Role = requesttravel.Role;
                rqtbl.TypeOfEmployment = requesttravel.TypeOfEmployment;
                rqtbl.TravelDate = requesttravel.TravelDate;
                rqtbl.TravelTime = requesttravel.TravelTime;
                rqtbl.TravelTopic = requesttravel.TravelTopic;
                rqtbl.DestinationCountry = requesttravel.DestinationCountry;
                rqtbl.PersonUpName = requesttravel.PersonUpName;
                rqtbl.TravelExpensePayer = requesttravel.TravelExpensePayer;
                rqtbl.IsFinal = requesttravel.IsFinal;
                await _context.RequestTravelTbl.AddAsync(requesttravel);
                await _context.SaveChangesAsync();

                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);
                //if (requesttravel.RequestStatusId == 1)
                //{
                //    rqtbl.ConfirmDate = date;

                //}
                var Req = await _context.RequestTravelTbl.AddAsync(rqtbl);
                await _context.SaveChangesAsync();

                //var data = await _agentRepository.GetAgentAsync(requesttravel.AgentId);
                //data.RequestTravelId = rqtbl.RequestTravelId;

                await _context.SaveChangesAsync();
                return requesttravel;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<RequestTravelDto?> RejectRequest(RequestTravelDto request)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRequestTravelAsync(int requesttravelId)
        {
            var data = _context.RequestTravelTbl.Find(requesttravelId);
            _context.RequestTravelTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RequestTravelExistsAsync(long requesttravelId)
        {
            return await _context.RequestTravelTbl.AnyAsync(f => f.RequestTravelId == requesttravelId);
        }
    

        public async Task<RequestTravelDto?> UpdateRequestTravelAsync(RequestTravelDto request)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        Task<RequestTbl?> IRequestTravelRepository.GetRequestTravelAsync(int RequesttravelId)
        {
            throw new NotImplementedException();
        }
    }
}
