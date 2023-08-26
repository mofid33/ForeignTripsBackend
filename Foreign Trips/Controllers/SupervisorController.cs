using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
//    [Route("api/Supervisor")]
//    public class OverseerController
//    {
//        private readonly IAgentRepository _agentRepository;
//        private readonly ISupervisorRepository _supervisorRepository;
//        private readonly IReportRepository _reportRepository;
//        private readonly IMapper _mapper;


//        public OverseerController(IAgentRepository agentRepository, ISupervisorRepository supervisorRepository,
//                                  IReportRepository reportRepository,
//                                  IMapper mapper)
//        {
//            _agentRepository = agentRepository ??
//                throw new ArgumentNullException(nameof(agentRepository));
//            _supervisorRepository = supervisorRepository ??
//               throw new ArgumentNullException(nameof(supervisorRepository));
//            _reportRepository = reportRepository ??
//            throw new ArgumentNullException(nameof(reportRepository));
//            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        }

//        [HttpGet]
//        [Route("GetSupervisor")]
//        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor()
//        {
//            var Overseer = await _supervisorRepository.GetSupervisor();

//            return Ok(
//                Overseer
//                );
//        }

//        [HttpPost]
//        [Route("InsertSupervisor")]
//        public async Task<ActionResult<SupervisorTbl>> InsertSupervisor(
//[FromBody] SupervisorTbl Model
//)
//        {

//            var over = await _supervisorRepository.InsertSupervisor(Model);
//            if (over == null)
//            {
//                return BadRequest();
//            }
//            return Ok(over);

//        }
//        [HttpPost]
//        [Route("UpdateSupervisor")]
//        public async Task<ActionResult<SupervisorTbl>> UpdateOverseerAsync(
//[FromBody] SupervisorTbl Model
//)
//        {
//            var Over = await _supervisorRepository.UpdateSupervisorAsync(Model);
//            if (Over == null)
//            {
//                return BadRequest();
//            }
//            return Ok();

//        }


//    }


//    [HttpGet]
//    [Route("GetReports")]
//    public async Task<ActionResult<IEnumerable<Report>>> GetReport()
//    {
//        var reports = await _reportRepository.GetReport();

//        return Ok(
//            reports
//            );
//    }

}
