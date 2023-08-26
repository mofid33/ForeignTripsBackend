using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
//    [Route("api/InternationalExpert")]
//    public class InternationalExpertController
//    {
//        private readonly IInternationalExpertRepository _internationalexpertRepository;
//        private readonly IMapper _mapper;


//        public InternationalExpertController(IInternationalExpertRepository internationalexpertRepository,
//                               IMapper mapper)
//        {
//            _internationalexpertRepository = internationalexpertRepository ??
//                throw new ArgumentNullException(nameof(internationalexpertRepository));

//            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        }


//        [HttpGet]
//        [Route("GetInternationalExpert")]
//        public async Task<ActionResult<IEnumerable<InternationalExpertTbl>>> GetInternationalExpert()
//        {
//            var interexpert = await _internationalexpertRepository.GetInternationalExpert();

//            return Ok(
//                interexpert
//                );
//        }





//        [HttpPost]
//        [Route("InsertInternationalExpert")]
//        public async Task<ActionResult<InternationalExpertTbl>> InsertInternationalExpert(
//    [FromBody] InternationalExpertTbl Model
//    )
//        {

//            var Inter = await _internationalexpertRepository.InsertInternationalExpert(Model);
//            if (Inter == null)
//            {
//                return BadRequest();
//            }
//            return Ok();

//        }




//        [HttpPost]
//        [Route("UpdateInternationalExpert")]
//        public async Task<ActionResult<InternationalExpertTbl>> UpdateInternationalExpert(
//[FromBody] InternationalExpertTbl Model
//)
//        {
//            if (!await _internationalexpertRepository.InternationalExpertExistsAsync(Model.InternationalExpertId))
//            {
//                return NotFound();
//            }
//            var Inter = await _internationalexpertRepository.UpdateInternationalExpert(Model);
//            if (Inter == null)
//            {
//                return BadRequest();
//            }
//            return Ok();
//        }




//        [HttpPost]
//        [Route("RemoveInternationalExpert")]
//        public async Task<ActionResult<InternationalExpertTbl>> RemoveInternationalExpert(
//[FromBody] InternationalExpertTbl Model
//)
//        {
//            try
//            {
//                if (!await _internationalexpertRepository.InternationalExpertExistsAsync(Model.AdminId))
//                {
//                    return NoContent();
//                }
//                _internationalexpertRepository.RemoveInternationalExpert(Model.InternationalExpertId);

//                return Ok();
//            }

//            catch (System.Exception ex)
//            {
//                return null;

//            }
//        }
//    }
}
