using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Controllers
{
    [Route("api/Agents")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public AgentController(IAgentRepository agentRepository, IAuthRepository authRepository, IReportRepository reportRepository, ITicketRepository ticketRepository, IRequestRepository requestRepository, IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
            _requestRepository = requestRepository ??
                throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = reportRepository ??
                throw new ArgumentNullException(nameof(reportRepository));
            _ticketRepository = ticketRepository ??
                throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



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
        
        [HttpGet]
        [Route("GetAgent")]
        public async Task<ActionResult<AgentDto>> GetAgent(long agentId)
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var AgentID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(agentId))
            {
                return NotFound();
            }
            var Agent = await _agentRepository.GetAgentAsync(AgentID);
            return Ok(
         _mapper.Map<AgentTbl>(Agent)
         );

        }

        [HttpGet]
        [Route("GetAgentStatus")]
        public async Task<ActionResult<IEnumerable<AgentStatusTbl>>> GetAgentStatus()
        {
            var agnets = await _agentRepository.GetAgentStatusAsync();

            return Ok(
                _mapper.Map<IEnumerable<AgentStatusTbl>>(agnets)
                );

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

        #region File
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _agentRepository.PostFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _agentRepository.PostMultiFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


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

        [HttpPost]
        [Route("RejectRequest")]
        public async Task<ActionResult<RequestDto>> RejectRequest(
[FromBody] RequestDto Model
)
        {

            var Req = await _requestRepository.RejectRequest(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet]
        [Route("GetRule")]
        public async Task<ActionResult<IEnumerable<RuleTbl>>> GetRule()
        {
            var rule = await _requestRepository.GetRule();

            return Ok(
                rule
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


        [HttpPost]
        [Route("InsertReport")]
        public async Task<ActionResult<Report>> InsertReport(
    [FromBody] Report Model
    )
        {

            var Rep = await _reportRepository.InsertReport(Model);
            if (Rep == null)
            {
                return BadRequest();
            }
            return Ok(Rep);

        }
        #endregion

        #region Ticket
        [HttpPost]
        [Route("GetTicket")]
        public async Task<ActionResult<TicketTbl>> GetTicket(
      [FromBody] GetTicket Model
      )
        {

            var Tickets = await _ticketRepository.GetTicket(Model.TicketID);
            return Ok(Tickets);

        }

        [HttpPost]
        [Route("InsertTicket")]
        public async Task<ActionResult<TicketTbl>> InsertTicket(
[FromBody] TicketTbl Model
)
        {

            var Ticket = await _ticketRepository.InsertTicket(Model);
            if (Ticket == null)
            {
                return BadRequest();
            }
            return Ok(Ticket);

        }
        #endregion
    }
}
