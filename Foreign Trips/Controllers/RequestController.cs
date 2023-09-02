using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Request")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;


        public RequestController(IRequestRepository requestRepository, IAgentRepository agentRepository,
                                  IMapper mapper)
        {
            _requestRepository = requestRepository ??
            throw new ArgumentNullException(nameof(requestRepository));
            _agentRepository = agentRepository ??
            throw new ArgumentNullException(nameof(agentRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetRequests")]
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest()
        {
            var Requests = await _requestRepository.GetRequest();

            return Ok(
                Requests
                );
        }


        [HttpPost]
        [Route("GetRequest")]
        public async Task<ActionResult<RequestTbl>> GetRequest(
     [FromBody] RequestTbl Model
     )
        {

            var req = await _requestRepository.GetRequestAsync(Model.RequestId);
            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }

        [HttpPost]
        [Route("GetnewRequest")]
        public async Task<ActionResult<RequestTbl>> GetNewRequest(
    [FromBody] RequestTbl Model
    )
        {

            var req = await _requestRepository.GetNewRequest(Model.RequestId);
            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }



        [HttpPost]
        [Route("InsertRequest")]
        public async Task<ActionResult<RequestTbl>> InsertRequest(
[FromBody] RequestTbl Model
            )

        {

            var Req = await _requestRepository.InsertRequestAsync(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }

        [HttpPost]
        [Route("UpdateRequest2")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest2Async(
[FromBody] RequestTbl Model
)
        {
            var Req = await _requestRepository.UpdateRequest2Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("UpdateRequest3")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest3Async(
[FromBody] RequestTbl Model
)
        {
            var Req = await _requestRepository.UpdateRequest3Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("UpdateRequest4")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest4Async(
[FromBody] RequestTbl Model
)
        {
            var Req = await _requestRepository.UpdateRequest4Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }








        [HttpPost]
        [Route("RemoveRequest")]
        public async Task<ActionResult<RequestTbl>> RemoveRequestAsync(
        [FromBody] RequestTbl Model
        )
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            _requestRepository.RemoveRequestAsync(Model.RequestId);

            return Ok();

        }

        [HttpPost]
        [Route("AcceptRequest")]
        public async Task<ActionResult<RequestTbl>> AcceptRequest(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            var req = await _requestRepository.AcceptRequest(Model);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok();

        }


        [HttpPost]
        [Route("RejectRequest")]
        public async Task<ActionResult<RequestTbl>> RejectRequest(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            var req = await _requestRepository.RejectRequest(Model);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok();

        }





    }
}




