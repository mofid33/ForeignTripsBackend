using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;


        public RequestController(IRequestRepository requestRepository,
                                  IAgentRepository agentRepository,
                                  IMapper mapper)
        {
            _requestRepository = requestRepository ??
            throw new ArgumentNullException(nameof(requestRepository));
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Get Request
        [HttpGet]
        [Route("GetRequests")]
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest()
        {
            var Requests = await _requestRepository.GetRequest();

            return Ok(
                Requests
                );
        }
        #endregion



        #region Insert Request
        [HttpPost]
        [Route("InsertRequest")]
        public async Task<ActionResult<RequestTbl>> InsertRequestAsync(
[FromBody] RequestTbl Model
)
        {

            var Eorgan = await _requestRepository.InsertRequestAsync(Model);
            if (Eorgan == null)
            {
                return BadRequest();
            }
            return Ok(Eorgan);

        }
        #endregion


        #region Reject Request
        [HttpPost]
        [Route("RejectRequest")]
        public async Task<ActionResult<AgentTbl>> RejectRequest(
[FromBody] RequestDto Model
)
        {

            var Eorgan = await _requestRepository.RejectRequest(Model);
            if (Eorgan == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion


        #region Edit
        [HttpPost]
        [Route("UpdateRequest")]
        public async Task<ActionResult<RequestTbl>> UpdateRequestAsync(
[FromBody] RequestDto Model
)
        {
            var Eorgan = await _requestRepository.UpdateRequestAsync(Model);
            if (Eorgan == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion



        #region Delete
        [HttpPost]
        [Route("RemoveRequest")]
        public async Task<ActionResult<RequestDto>> RemoveRequestAsync(
        [FromBody] RequestDto Model
        )
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            _requestRepository.RemoveRequestAsync(Model.RequestId);

            return Ok();

        }
        #endregion
    }
}




