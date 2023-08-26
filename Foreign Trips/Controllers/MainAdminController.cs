using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Foreign_Trips.Controllers
{
    [Route("api/Supervisor")]
    public class MainAdminController: ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMainAdminRepository _mainadminRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IInternationalAdminRepository _internatinaladminRepository;
        private readonly IReportRepository _reportRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public MainAdminController(IAgentRepository agentRepository, IMainAdminRepository mainadminRepository, IAuthRepository authRepository,
                                   IInternationalAdminRepository internatinaladminRepository, IReportRepository reportRepository,
                                   ISupervisorRepository supervisorRepository, ITicketRepository ticketRepository,
        IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _mainadminRepository = mainadminRepository ??
               throw new ArgumentNullException(nameof(mainadminRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
            _internatinaladminRepository = internatinaladminRepository ??
               throw new ArgumentNullException(nameof(internatinaladminRepository));
            _reportRepository = reportRepository ??
               throw new ArgumentNullException(nameof(reportRepository));
            _supervisorRepository = supervisorRepository ??
               throw new ArgumentNullException(nameof(supervisorRepository));
            _ticketRepository = ticketRepository ??
               throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetMainAdmin")]
        public async Task<ActionResult<IEnumerable<MainAdminTbl>>> GetMainadmin()
        {
            var Supervisor= await _mainadminRepository.GetMainAdmin();

            return Ok(
                Supervisor
                );
        }

        [HttpPost]
        [Route("Insert<AinAdmin")]
        public async Task<ActionResult<MainAdminTbl>> InsertMainAdmin(
[FromBody] MainAdminTbl Model
)
        {

            var Sup = await _mainadminRepository.InsertMainAdmin(Model);
            if (Sup == null)
            {
                return BadRequest();
            }
            return Ok(Sup);

        }
        [HttpPost]
        [Route("UpdateMainAdmin")]
        public async Task<ActionResult<MainAdminTbl>> UpdateMainAdminAsync(
[FromBody] MainAdminTbl Model
)
        {
            var Sup = await _mainadminRepository.UpdateMainAdminAsync(Model);
            if (Sup == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentTbl>> InsertAgnet(
        [FromBody] AgentTbl Model
        )
        {

            var Sup = await _agentRepository.InsertAgentAsync(Model);
            if (Sup == null)
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
            var Sup = await _agentRepository.UpdateAgentAsync(Model);
            if (Sup == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("DeleteAgent")]
        public async Task<ActionResult<AgentTbl>> DeleteAgent(
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
        [Route("SuspendAgent")]
        public async Task<ActionResult<AgentTbl>> SuspendAgent(
[FromBody] GetAgent Model
)
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            await _agentRepository.SuspendAgentAsync(Model.AgentId);

            return Ok();

        }

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

        [HttpGet]
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


        #endregion

        #region Supervisor
        [HttpGet]
        [Route("GetSupervisor")]
        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor()
        {
            var sup = await _supervisorRepository.GetSupervisor();

            return Ok(
                sup
                );
        }

        [HttpPost]
        [Route("InsertSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> InsertSupervisor(
[FromBody] SupervisorTbl Model
)
        {

            var sup = await _supervisorRepository.InsertSupervisor(Model);
            if (sup == null)
            {
                return BadRequest();
            }
            return Ok(sup);

        }

        [HttpPost]
        [Route("UpdateSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> UpdateOverseerAsync(
[FromBody] SupervisorTbl Model
)
        {
            var sup = await _supervisorRepository.UpdateSupervisorAsync(Model);
            if (sup == null)
            {
                return BadRequest();
            }
            return Ok();

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

        #region Log
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

        #endregion

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
        [HttpPost]
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
