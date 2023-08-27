﻿using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Controllers
{
    [Route("api/Supervisor")]
    public class OverseerController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;


        public OverseerController(IAgentRepository agentRepository, ISupervisorRepository supervisorRepository,
                                  IReportRepository reportRepository,
                                  IMapper mapper)
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



        [HttpGet]
        [Route("GetAgent")]
        public async Task<ActionResult<AgentTbl>> GetAgent(
           [FromBody] AgentTbl Model
           )
        {

            var agents = await _supervisorRepository.GetAgentAsync(Model.AgentId);
            return Ok(
         _mapper.Map<AgentTbl>(agents)
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


        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();

            return Ok(
                reports
                );
        }

    }
}
