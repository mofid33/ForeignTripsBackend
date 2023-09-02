﻿using AutoMapper;
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

        //[HttpGet]
        //[Route("GetAgentStatus")]
        //public async Task<ActionResult<IEnumerable<AgentStatusTbl>>> GetAgentStatus()
        //{
        //    var agnets = await _agentRepository.GetAgentStatusAsync();

        //    return Ok(
        //        _mapper.Map<IEnumerable<AgentStatusTbl>>(agnets)
        //        );

        //}



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
        public async Task<ActionResult<AgentTbl>> UpdateAgentAsync(
[FromBody] AgentTbl Model
)
        {
            var agent = await _agentRepository.UpdateAgentAsync(Model);
            if (agent == null)
            {
                return BadRequest();
            }
            return Ok();

        }




        //[HttpPost]
        //[Route("DeleteAgent")]
        //public async Task<ActionResult<AgentTbl>> DeleteAgentAsync(
        //[FromBody] AgentTbl Model
        //)
        //{
        //    if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
        //    {
        //        return NotFound();
        //    }
        //    _agentRepository.DeleteAgent(Model.AgentId);

        //    return Ok();

        //}


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
        [Route("GetRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> GetRequestEmployee(
     [FromBody] RequestEmployeeTbl Model
     )
        {

            var req = await _requestRepository.GetRequestEmployeeAsync(Model.RequestId);
            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }

        [HttpPost]
        [Route("GetRequest")]
        public async Task<ActionResult<RequestTbl>> GetRequest(
     [FromBody] RequestTbl Model
     )
        {

            var req = await _requestRepository.GetRequestAsync(Model.RequestId);
            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }





        [HttpPost]
        [Route("InsertRequest")]
        public async Task<ActionResult<RequestTbl>> InsertRequest(
[FromBody] RequestTbl Model
            )

        {

            var Req = await _requestRepository.InsertRequestAsync(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }

        [HttpPost]
        [Route("InsertRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> InsertRequestEmployeeAsync(
[FromBody] RequestEmployeeTbl Model
)
        {
            var Req = await _requestRepository.InsertRequestEmployeeAsync(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("UpdateRequest3")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest3Async(
[FromBody] RequestTbl Model
)
        {
            var Req = await _requestRepository.UpdateRequest3Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("UpdateRequest4")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest4Async(
[FromBody] RequestTbl Model
)
        {
            var Req = await _requestRepository.UpdateRequest4Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

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
        [Route("GetReport")]
        public async Task<ActionResult<Report>> GetReport(
     [FromBody] Report Model
     )
        {

            var rep = await _reportRepository.GetReportAsync(Model.ReportId);
            return Ok(
         _mapper.Map<Report>(rep)
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

        [HttpGet]
        [Route("GetTickets")]
        public async Task<ActionResult<TicketTbl>> GetTickets()
        {

            var Tickets = await _ticketRepository.GetTickets();

            return Ok(_mapper.Map<IEnumerable<TicketTbl>>(Tickets));

        }

        [HttpPost]
        [Route("GetTicket")]
        public async Task<ActionResult<TicketTbl>> GetTicket(
       [FromBody] GetTicket Model
       )
        {

            var Tickets = await _ticketRepository.GetTicketAsync(Model.TicketID);
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

        #region province
        [HttpGet]
        [Route("GetProvinces")]
        public async Task<ActionResult<IEnumerable<ProvinceTbl>>> GetProvinces()
        {
            var Organs = await _agentRepository.GetProvincesAcync();

            return Ok(
                _mapper.Map<IEnumerable<ProvinceTbl>>(Organs)
                );

        }
        [HttpGet]
        [Route("GetCities")]
        public async Task<ActionResult<CityTbl>> GetCities(
        [FromBody] CityTbl Model
)
        {


            var Cities = await _agentRepository.GetCitiesAcync(Model.ProvinceId);
            return Ok(
         //_mapper.Map<CityTbl>(Cities)
         Cities
         );

        }
        #endregion

    }
}
