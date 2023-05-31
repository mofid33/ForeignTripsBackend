using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;


        public AdminController(IAdminRepository adminRepository,
                               IAgentRepository agentRepository,
                               IMapper mapper)
        {
            _adminRepository = adminRepository ??
                throw new ArgumentNullException(nameof(adminRepository));
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        #region Get Agent
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents()
        {
            var Agents = await _adminRepository.GetAgent();

            return Ok(
                Agents
                );
        }
        #endregion


        #region User Login
        [HttpPost]
        [Route("GetUserLog")]
        public async Task<ActionResult<LoginTbl>> GetUserLog(
[FromBody] LoginTbl Model
)
        {

            var logUser = await _adminRepository.GetUserLog(Model);
            if (logUser == null)
            {
                return BadRequest();
            }
            return Ok(
                  _mapper.Map<LoginTbl>(logUser)
                  );
        }
        #endregion


        #region Insert
        [HttpPost]
        [Route("InsertAdmin")]
        public async Task<ActionResult<AdminTbl>> InsertAdmin(
    [FromBody] AdminTbl Model
    )
        {

            var EAgent = await _adminRepository.InsertAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion


        #region Edit
        [HttpPost]
        [Route("UpdateAdmin")]
        public async Task<ActionResult<AdminTbl>> UpdateAdmin(
[FromBody] AdminTbl Model
)
        {
            if (!await _adminRepository.AdminExistsAsync(Model.AdminId))
            {
                return NotFound();
            }
            var EAgent = await _adminRepository.UpdateAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        #endregion


        //#region Delete
        //[HttpPost]
        //[Route("RemoveAdmin")]
        //public async Task<ActionResult<AdminTbl>> RemoveAdmin(
//[FromBody]  AdminTbl Model
//)
       // {
            //if (!await _adminRepository.AdminExistsAsync(Model.AdminId))
            //{
            //  return NotFound();
            //}
            //_agentRepository.RemoveAgentAsync(Model.AdminId);

            //return Ok();

        //}
       // #endregion
    }
}
