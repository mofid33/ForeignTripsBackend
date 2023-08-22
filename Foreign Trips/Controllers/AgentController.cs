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
        private readonly IMapper _mapper;
        public AgentController(IAgentRepository agentRepository, IAuthRepository authRepository, IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
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




        
        //[HttpPost]
        //[Route("RemoveAgent")]
        //public async Task<ActionResult<AgentTbl>> RemoveAgent(
        //[FromBody] AgentTbl Model
        //)
        //{
        //    if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
        //    {
        //        return NotFound();
        //    }
        //    _agentRepository.RemoveAgentAsync(Model.AgentId);

        //    return Ok();

        //}


      
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
        [Route("InsertPassPort")]
        public async Task<ActionResult<AgentTbl>> InsertPassPort(
[FromBody] AgentTbl Model
)
        {

            var Eagent = await _agentRepository.InsertPassPortAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }
            return Ok(Eagent);

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




    }
}
