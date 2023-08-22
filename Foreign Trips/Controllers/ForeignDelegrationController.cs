using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/ForeignDelegration")]
    public class ForeignDelegrationController : ControllerBase
    {

        private readonly IForeignDelegrationRepository _foreigndelegrationRepository;
        private readonly IMapper _mapper;
        public ForeignDelegrationController(IForeignDelegrationRepository foreigndelegrationRepository,
                                            IMapper mapper)
        {
            _foreigndelegrationRepository = foreigndelegrationRepository ??
                    throw new ArgumentNullException(nameof(foreigndelegrationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetForeignDelegrations")]
        public async Task<ActionResult<IEnumerable<ForeignDelegrationTbl>>> GetForeginDelegration()
        {
            var ForeignDelegrations = await _foreigndelegrationRepository.GetForeginDelegration();

            return Ok(
                ForeignDelegrations
                );
        }

        [HttpPost]
        [Route("InsertForeignDelegrations")]
        public async Task<ActionResult<ForeignDelegrationTbl>> InsertForeignDelegration(
[FromBody] ForeignDelegrationTbl Model
)
        {

            var Efd = await _foreigndelegrationRepository.InsertForeginDelegration(Model);
            if (Efd == null)
            {
                return BadRequest();
            }
            return Ok(Efd);

        }
        [HttpPost]
        [Route("UpdateForeginDelegration")]
        public async Task<ActionResult<ForeignDelegrationTbl>> UpdateForeginDelegration(
[FromBody] ForeignDelegrationTbl Model
)
        {
            var Efd = await _foreigndelegrationRepository.UpdateForeginDelegration(Model);
            if (Efd == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("RemoveForeginDelegration")]
        public async Task<ActionResult<ForeignDelegrationTbl>> RemoveForeginDelegratio(
        [FromBody] ForeignDelegrationTbl Model
        )
        {
            try
            {
                if (!await _foreigndelegrationRepository.ForeginDelegrationExistsAsync(Model.ForeignDelegationId))
                {
                    return NoContent();
                }
                _foreigndelegrationRepository.RemoveForeginDelegrationAsync(Model.ForeignDelegationId);

                return Ok();
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

    }
}

