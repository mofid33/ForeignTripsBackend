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
        [Route("InsertRequest1")]
        public async Task<ActionResult<RequestTbl>> InsertRequest1(
[FromBody] RequestTbl Model
)
        {

            var Req = await _requestRepository.InsertRequest1Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }

        [HttpPost]
        [Route("InsertRequest2")]
        public async Task<ActionResult<RequestTbl>> InsertRequest2(
[FromBody] RequestTbl Model
)
        {

            var Req = await _requestRepository.InsertRequest2Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }

        [HttpPost]
        [Route("InsertRequest3")]
        public async Task<ActionResult<RequestTbl>> InsertRequest3(
[FromBody] RequestTbl Model
)
        {

            var Req = await _requestRepository.InsertRequest3Async(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }



        [HttpPost]
        [Route("RejectRequest")]
        public async Task<ActionResult<RequestDto>> RejectRequest(
[FromBody] RequestDto Model
)
        {

            var Req = await _requestRepository.RejectRequest(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok();

        }



        [HttpPost]
        [Route("UpdateRequest")]
        public async Task<ActionResult<RequestTbl>> UpdateRequestAsync(
[FromBody] RequestDto Model
)
        {
            var Req = await _requestRepository.UpdateRequestAsync(Model);
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


        #region RequestStatus
        [HttpGet]
        [Route("GetRequestStatus")]
        public async Task<ActionResult<IEnumerable<RequestStatusTbl>>> GetRequestStatus()
        {
            var Agents = await _requestRepository.GetRequestStatusAsync();

            return Ok(
                _mapper.Map<IEnumerable<RequestStatusTbl>>(Agents)
                );

        }
        #endregion

        #region Get Rule
        [HttpGet]
        [Route("GetRule")]
        public async Task<ActionResult<IEnumerable<RuleTbl>>> GetRule()
        {
            var rule = await _requestRepository.GetRule();

            return Ok(
                rule
                );
        }
        #endregion

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




