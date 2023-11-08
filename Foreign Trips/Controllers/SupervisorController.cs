using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using ShenaseMeliBac.Profiles;
using static NPOI.HSSF.Util.HSSFColor;

namespace Foreign_Trips.Controllers
{
    [Route("api/Supervisor")]
    public class SupervisorController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;


        public SupervisorController(IAgentRepository agentRepository, ISupervisorRepository supervisorRepository,
                                  IReportRepository reportRepository, IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _supervisorRepository = supervisorRepository ??
               throw new ArgumentNullException(nameof(supervisorRepository));
            _reportRepository = reportRepository ??
            throw new ArgumentNullException(nameof(reportRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetSupervisor")]
        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var sup = await _supervisorRepository.GetSupervisor(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (sup == null)
            {
                return BadRequest();
            }
            return Ok(
                sup
                );
        }

        [HttpPost]
        [Route("GetSupervisors")]
        public async Task<ActionResult<SupervisorTbl>> GetSupervisors(
             [FromBody] SupervisorTbl Model
             )
        {

            var sup = await _supervisorRepository.GetSupervisorAsync(Model.SupervisorId);
            if (sup == null)
            {
                return BadRequest();
            }
 

            return Ok(
         _mapper.Map<SupervisorTbl>(sup)
         );

        }

        [HttpPost]
        [Route("InsertSupervisor")]
        public async Task<ActionResult<SupervisorDto>> InsertSupervisor(
[FromBody] SupervisorDto Model
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
        public async Task<ActionResult<SupervisorTbl>> UpdateSupervisorAsync(
[FromBody] SupervisorTbl Model
)
        {
            if (!await _supervisorRepository.SupervisorExistsAsync(Model.SupervisorId))
            {
                return NoContent();
            }
            var sup = await _supervisorRepository.UpdateSupervisorAsync(Model);
            if (sup == null)
            {
                return BadRequest();
            }

            return Ok(sup); ;

        }

        [HttpPost]
        [Route("RemoveSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> RemoveSupervisorAsync(
       [FromBody] SupervisorTbl Model
       )
        {
           
            var sup = await _supervisorRepository.RemoveSupervisorAsync(Model.SupervisorId);
            if (sup == null)
            {
                return BadRequest();
            } 

            return Ok(sup);

        }


        #region Agent

        [HttpGet]
        [Route("GetAgents")]

        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, String search)
        {
            var Agents = await _agentRepository.GetAgent(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (Agents == null)
            {
                return BadRequest();
            }
            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Agents
                );
        }
        #endregion


        #region Report

        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<IEnumerable<ReportTbl>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();
            if (reports == null)
            {
                return BadRequest();
            }
            return Ok(
                reports
                );
        }

        [HttpGet]
        [Route("GetReport")]
        public async Task<ActionResult<ReportTbl>> GetReport(
     [FromBody] ReportTbl Model
     )
        {

            var rep = await _reportRepository.GetReportAsync(Model.ReportId);
            if (reports == null)
            {
                return BadRequest();
            }
            return Ok(
         _mapper.Map<ReportTbl>(rep)
         );

        }

        #endregion


       

    }
}


