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


        #region Get Agent
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
        #endregion


        #region Get
        [HttpGet]
        [Route("GetAgent")]
        public async Task<ActionResult<AgentDto>> GetAgent(long agentId)
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var OrganID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(agentId))
            {
                return NotFound();
            }
            var Agent = await _agentRepository.GetAgentAsync(OrganID);
            return Ok(
         _mapper.Map<AgentTbl>(Agent)
         );

        }
        #endregion


        #region Insert Agent
        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentDto>> InsertAgnet(
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
        #endregion



        #region Edit
        [HttpPost]
        [Route("UpdateAgnet")]
        public async Task<ActionResult<AgentDto>> UpdateAgnet(
        [FromBody] AgentDto Model
             )
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var AgnetID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(AgnetID))
            {
                return NotFound();
            }
            var Eagent = await _agentRepository.UpdateAgentAsync(Model, AgnetID);
            if (Eagent == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion



        #region Delete
        [HttpPost]
        [Route("RemoveAgent")]
        public async Task<ActionResult<AgentDto>> RemoveAgent(
        [FromBody] AgentDto Model
        )
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            _agentRepository.RemoveAgentAsync(Model.AgentId);

            return Ok();

        }
        #endregion



        #region Delete
        [HttpPost]
        [Route("RemoveRequest")]
        public async Task<ActionResult<AgentDto>> RemoveAgentAsync(
        [FromBody] AgentDto Model
        )
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            _agentRepository.RemoveAgentAsync(Model.AgentId);

            return Ok();

        }
        #endregion


    }
}
