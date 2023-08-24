using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Foreign_Trips.Controllers
{
    [Route("api/Supervisor")]
    public class SupervisorController: ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public SupervisorController(IAgentRepository agentRepository, ISupervisorRepository supervisorRepository, IAuthRepository authRepository,
                                IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _supervisorRepository = supervisorRepository ??
               throw new ArgumentNullException(nameof(supervisorRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetSupervisor")]
        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor()
        {
            var Supervisor= await _supervisorRepository.GetSupervisor();

            return Ok(
                Supervisor
                );
        }

        [HttpPost]
        [Route("InsertSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> InsertSupervisor(
[FromBody] SupervisorTbl Model
)
        {

            var Sup = await _supervisorRepository.InsertSuperviser(Model);
            if (Sup == null)
            {
                return BadRequest();
            }
            return Ok(Sup);

        }
        [HttpPost]
        [Route("UpdateSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> UpdateSupervisorAsync(
[FromBody] SupervisorTbl Model
)
        {
            var Sup = await _supervisorRepository.UpdateSuperviserAsync(Model);
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
