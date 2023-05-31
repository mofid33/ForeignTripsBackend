using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AgentDbContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IAgentRepository _agentRepository;

        public RequestRepository(AgentDbContext context, IRequestRepository requestRepository, IAgentRepository agentRepository)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _requestRepository = requestRepository ??
               throw new ArgumentNullException(nameof(requestRepository));
            _agentRepository = agentRepository ??
               throw new ArgumentNullException(nameof(agentRepository));


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
            return await _context.RequestTbl.Where(f => f.RequestId == requestId).FirstOrDefaultAsync();
        }

        public async Task<RequestTbl?> InsertRequestAsync(RequestTbl request)
        {
            try
            {
                RequestTbl qtbl = new RequestTbl();
                qtbl.RequestId = request.RequestId;
                qtbl.AgentId = request.AgentId;
                qtbl.RequestStatusId = request.RequestStatusId;
                qtbl.NationalCode = request.NationalCode;
                qtbl.Role = request.Role;
                qtbl.WorkLocation = request.WorkLocation;
                qtbl.TypeOfEmployment = request.TypeOfEmployment;
                qtbl.TravelDate = request.TravelDate;
                qtbl.TravelTime = request.TravelTime;
                qtbl.TravelTopic = request.TravelTopic;
                qtbl.DestinationCountry = request.DestinationCountry;
                qtbl.Payer = request.Payer;
                qtbl.TravelCost= request.TravelCost;
                qtbl.RejectDescription = request.RejectDescription;
                qtbl.ConfirmDate = request.ConfirmDate;
                await _context.RequestTbl.AddAsync(request);
                await _context.SaveChangesAsync();

                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);
                if (request.RequestStatusId == 1)
                {
                 qtbl.ConfirmDate = date;

            }
                  var Req = await _context.RequestTbl.AddAsync(qtbl);
                  await _context.SaveChangesAsync();
            
                  //var data = await _agentRepository.GetAgentAsync(request.AgentId);
                  //data.RequestId = qtbl.RequestId;
            
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

        public async Task<bool> RequestExistsAsync(long RequestId)
        {
            return await _context.RequestTbl.AnyAsync(f => f.RequestId == RequestId);
        }


        public async Task<RequestDto?> RejectRequest(RequestDto request)
        {
            try
            {
                var data = await _agentRepository.GetAgentAsync(request.AgentID);
                data.RejectDescription = request.RejectDescription;

                await _context.SaveChangesAsync();
                return request;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
        public async Task<RequestDto?> UpdateRequestAsync(RequestDto request)
        {
            try
            {
                var req = await _requestRepository.GetRequestAsync(request.RequestId);
                req.RequestStatusId = request.RequestStatusID;
                req.RequestStatusId = request.RequestStatusID;


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

        
    }
}
