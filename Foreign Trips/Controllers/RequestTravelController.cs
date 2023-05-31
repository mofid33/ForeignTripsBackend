using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    public class RequestTravelController : ControllerBase
    {
        private readonly IRequestTravelRepository _requesttravelRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public RequestTravelController(IRequestTravelRepository requesttravelRepository,
                                         IAgentRepository agentRepository,
                                         IMapper mapper)
        {
            _requesttravelRepository = requesttravelRepository ??
            throw new ArgumentNullException(nameof(requesttravelRepository));
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        #region Get Request
        [HttpGet]
        [Route("GetRequestTravels")]
        public async Task<ActionResult<IEnumerable<RequestTravelTbl>>> GetRequestTravel()
        {
            var RequestTravels = await _requesttravelRepository.GetRequestTravel();

            return Ok(
                RequestTravels
                ) ;
        }
        #endregion



        #region Insert Request
        [HttpPost]
        [Route("InsertRequest")]
        public async Task<ActionResult<RequestTravelTbl>> InsertRequestTravelAsync(
[FromBody] RequestTravelTbl Model
)
        {

            var Ereq = await _requesttravelRepository.InsertRequestTravelAsync(Model);
            if (Ereq == null)
            {
                return BadRequest();
            }
            return Ok(Ereq);

        }
        #endregion



        #region Edit
        [HttpPost]
        [Route("UpdateRequestTravel")]
        public async Task<ActionResult<RequestTravelTbl>> UpdateRequestTravelAsync(
[FromBody] RequestTravelDto Model
)
        {
            var Ereq = await _requesttravelRepository.UpdateRequestTravelAsync(Model);
            if (Ereq == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion



        #region Delete
        [HttpPost]
        [Route("RemoveRequestTravel")]
        public async Task<ActionResult<RequestTravelDto>> RemoveRequestTravelAsync(
        [FromBody] RequestTravelDto Model
        )
        {
            if (!await _requesttravelRepository.RequestTravelExistsAsync(Model.RequestTravelId))
            {
                return NotFound();
            }
            _requesttravelRepository.RemoveRequestTravelAsync(Model.RequestTravelId);

            return Ok();

        }
        #endregion
    }
}

