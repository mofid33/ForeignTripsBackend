using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IInternationalAdminRepository _adminRepository;
        private readonly IMapper _mapper;


        public AdminController(IInternationalAdminRepository adminRepository,
                               IMapper mapper)
        {
            _adminRepository = adminRepository ??
                throw new ArgumentNullException(nameof(adminRepository));
       
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents()
        {
            var Agents = await _adminRepository.GetUser();

            return Ok(
                Agents
                );
        }
       


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



      
        [HttpPost]
        [Route("InsertInternationalAdminTbl")]
        public async Task<ActionResult<InternationalAdminTbl>> InsertAdmin(
    [FromBody] InternationalAdminTbl Model
    )
        {

            var EAgent = await _adminRepository.InsertAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();

        }




        [HttpPost]
        [Route("UpdateAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> UpdateAdmin(
[FromBody] InternationalAdminTbl Model
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




        [HttpPost]
        [Route("RemoveAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> RemoveAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            try
            {
                if (!await _adminRepository.AdminExistsAsync(Model.AdminId))
                {
                    return NoContent();
                }
                _adminRepository.RemoveAdmin(Model.AdminId);

                return Ok();
            }
            
                 catch (System.Exception ex)
            {
                return null;

            }
        }

    }
}
