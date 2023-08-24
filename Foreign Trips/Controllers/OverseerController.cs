using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace Foreign_Trips.Controllers
{
//    [Route("api/Overseer")]
//    public class OverseerController
//    {
//        private readonly IAgentRepository _agentRepository;
//        private readonly IOverseerRepository _overseerRepository;
//        private readonly IMapper _mapper;
//        public OverseerController(IAgentRepository agentRepository, IOverseerRepository overseerRepository,
//                                IMapper mapper)
//        {
//            _agentRepository = agentRepository ??
//                throw new ArgumentNullException(nameof(agentRepository));
//            _overseerRepository = overseerRepository??
//               throw new ArgumentNullException(nameof(_overseerRepository));
//            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        }

//        [HttpGet]
//        [Route("GetOverseer")]
//        public async Task<ActionResult<IEnumerable<OverseerTbl>>> GetOverseer()
//        {
//            var Overseer = await _overseerRepository.GetOverseer();

//            return Ok(
//                Overseer
//                );
//        }

//        [HttpPost]
//        [Route("InsertOverseer")]
//        public async Task<ActionResult<OverseerTbl>> InsertOverseer(
//[FromBody] OverseerTbl Model
//)
//        {

//            var over = await _overseerRepository.InsertOverseer(Model);
//            if (over == null)
//            {
//                return BadRequest();
//            }
//            return Ok(over);

//        }
//        [HttpPost]
//        [Route("UpdateOverseer")]
//        public async Task<ActionResult<OverseerTbl>> UpdateOverseerAsync(
//[FromBody] OverseerTbl Model
//)
//        {
//            var Over = await _overseerRepository.UpdateOverseerAsync(Model);
//            if (Over == null)
//            {
//                return BadRequest();
//            }
//            return Ok();

//        }

        
//    }
}
