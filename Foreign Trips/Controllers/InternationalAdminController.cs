using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Admin")]
    public class InternationalAdminController : ControllerBase
    {
        private readonly IInternationalAdminRepository _internatinaladminRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IAuthRepository _authRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;


        public InternationalAdminController(IInternationalAdminRepository internatinaladminRepository, IRequestRepository requestRepository,
                                            IReportRepository reportRepository, IAgentRepository agentRepository, ITicketRepository ticketRepository,
                                            IMapper mapper)
        {
            _internatinaladminRepository = internatinaladminRepository ??
                throw new ArgumentNullException(nameof(internatinaladminRepository));
            _requestRepository = _requestRepository ??
                    throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = _reportRepository ??
                    throw new ArgumentNullException(nameof(reportRepository));
            _agentRepository = _agentRepository ??
                    throw new ArgumentNullException(nameof(agentRepository));
            _agentRepository = _agentRepository ??
                    throw new ArgumentNullException(nameof(_agentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents()
        {
            var Agents = await _internatinaladminRepository.GetUser();

            return Ok(
                Agents
                );
        }
       


        [HttpPost]
        [Route("GetUserLog")]
        public async Task<ActionResult<LoginTbl>> GetUserLog(
[FromBody] LoginTbl Model
)
        {

            var logUser = await _internatinaladminRepository.GetUserLog(Model);
            if (logUser == null)
            {
                return BadRequest();
            }
            return Ok(
                  _mapper.Map<LoginTbl>(logUser)
                  );
        }



      
        [HttpPost]
        [Route("InsertInternationalAdminTbl")]
        public async Task<ActionResult<InternationalAdminTbl>> InsertAdmin(
    [FromBody] InternationalAdminTbl Model
    )
        {

            var EAgent = await _internatinaladminRepository.InsertAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();

        }




        [HttpPost]
        [Route("UpdateAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> UpdateAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            if (!await _internatinaladminRepository.AdminExistsAsync(Model.AdminId))
            {
                return NotFound();
            }
            var EAgent = await _internatinaladminRepository.UpdateAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();
        }




        [HttpPost]
        [Route("RemoveAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> RemoveAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            try
            {
                if (!await _internatinaladminRepository.AdminExistsAsync(Model.AdminId))
                {
                    return NoContent();
                }
                _internatinaladminRepository.RemoveAdmin(Model.AdminId);

                return Ok();
            }
            
                 catch (System.Exception ex)
            {
                return null;

            }
        }

        #region Request
        [HttpGet]
        [Route("GetRequests")]
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest()
        {
            var Requests = await _requestRepository.GetRequest();

            return Ok(
                Requests
                );
        }


        #endregion


        #region Report

        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();

            return Ok(
                reports
                );
        }

        #endregion

        #region Agent
        [HttpGet]
        [Route("GetAgents")]
        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgent()
        {
            var Agents = await _agentRepository.GetAgent();

            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Agents
                );
        }

        [HttpPost]
        [Route("RemoveAgent")]
        public async Task<ActionResult<AgentTbl>> RemoveAgentAsync(
        [FromBody] AgentTbl Model
        )
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            _agentRepository.DeleteAgent(Model.AgentId);

            return Ok();

        }

        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentTbl>> InsertAgnet(
        [FromBody] AgentTbl Model
        )
        {

            var Eagent = await _agentRepository.InsertAgentAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }

            return Ok();

        }



        [HttpPost]
        [Route("UpdateAgnet")]
        public async Task<ActionResult<AgentTbl>> UpdateAgnet(
        [FromBody] AgentTbl Model
             )
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var AgnetID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(AgnetID))
            {
                return NotFound();
            }
            var Eagent = await _agentRepository.UpdateAgentAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        #endregion

        #region Ticket

        [HttpGet]
        [Route("GetTickets")]
        public async Task<ActionResult<TicketTbl>> GetTickets()
        {

            var Tickets = await _ticketRepository.GetTickets();

            return Ok(_mapper.Map<IEnumerable<TicketTbl>>(Tickets));

        }

        #endregion

    }
}
