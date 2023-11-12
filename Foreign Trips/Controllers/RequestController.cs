using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using static NPOI.HSSF.Util.HSSFColor;

namespace Foreign_Trips.Controllers
{
    [Route("api/Request")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IAuthRepository _authRepository;
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
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var Requests = await _requestRepository.GetRequest(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (Requests == null)
            {
                return BadRequest();
            }
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
            if (req == null)
            {
                return BadRequest();
            }

            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }

        [HttpGet]
        [Route("GetRequestsAgent")]
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequestAgent([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var AgentID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(AgentID))
            {
                return NotFound();
            }
            var Agent = await _agentRepository.GetAgentAsync(AgentID);
            if (Agent == null)
            {
                return BadRequest();
            }
            var Requests = await _requestRepository.GetRequestsAgent(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search, AgentID);
            if (Requests == null)
            {
                return BadRequest();
            }
            return Ok(
                Requests
                );
        }


        [HttpPost]
        [Route("GetRequestsExpert")]


        public async Task<ActionResult<TicketTbl>> GetRequestExpert([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search, [FromBody] RequestTbl Model)
        {

            var req = await _requestRepository.GetRequestsExpert(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search, Convert.ToInt32(Model.InternationalExpertId));
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(req);

        }

        [HttpPost]
        [Route("GetRequestsAdmin")]


        public async Task<ActionResult<TicketTbl>> GetRequestAdmin([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search, [FromBody] RequestTbl Model)
        {

            var req = await _requestRepository.GetRequestsAdmin(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search, Convert.ToInt32(Model.AdminId));
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(req));

        }

        [HttpPost]
        [Route("GetRequestsMainAdmin")]


        public async Task<ActionResult<TicketTbl>> GetRequestMainAdmin([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search, [FromBody] RequestTbl Model)
        {

            var req = await _requestRepository.GetRequestsMainAdmin(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search, Convert.ToInt32(Model.MainAdminId));
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(req));

        }



        [HttpPost]
        [Route("GetRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> GetRequestEmployee(
     [FromBody] RequestEmployeeTbl Model
     )
        {

            var req = await _requestRepository.GetRequestEmployeeAsync(Model.RequestId);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(req);

        }


        [HttpPost]
        [Route("GetnewRequest")]
        public async Task<ActionResult<RequestTbl>> GetNewRequest(
    [FromBody] RequestTbl Model
    )
        {

            var req = await _requestRepository.GetNewRequest(Model.RequestId);
            if (req == null)
            {
                return BadRequest();
            }

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
        [Route("InsertRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> InsertRequestEmployeeAsync(
[FromBody] RequestEmployeeTbl Model
)
        {

            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }

            var request = await _requestRepository.InsertRequestEmployeeAsync(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        [HttpPost]
        [Route("UpdateRequest3")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest3Async(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NoContent();
            }

            var request = await _requestRepository.UpdateRequest3Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        [HttpPost]
        [Route("UpdateRequest4")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest4Async(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NoContent();
            }

            var request = await _requestRepository.UpdateRequest4Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

       

        [HttpPost]
        [Route("UpdateRequest5")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest5Async(
[FromBody] RequestTbl Model
)
        {

                if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
                {
                   return NoContent();
                }


            var request = await _requestRepository.UpdateRequest5Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }
      


        [HttpPost]
        [Route("RemoveRequest")]
        public async Task<ActionResult<RequestTbl>> RemoveRequestAsync(
        [FromBody] RequestTbl Model
        )
        {

            var request = await _requestRepository.RemoveRequestAsync(Model.RequestId) ;
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }
      


        [HttpPost]
        [Route("RemoveEmployeeRequest")]
        public async Task<ActionResult<RequestEmployeeTbl>> RemoveRequestEmployeeAsync(
        [FromBody] RequestEmployeeTbl Model
        )

        {
         

            var request = await _requestRepository.RemoveRequestEmployeeAsync(Model.RequestEmployeeId);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        //#region signature

        //[HttpPost("Post Signature")]
        //public async Task<ActionResult> PostPhoto([FromForm] PhotoUploadModel signature)
        //{
        //    var sign = await _requestRepository.SignatureAsync(signature);

        //    if (sign == null)
        //    {
        //        return BadRequest();
        //    }

        //    else
        //    {
        //        return Ok();
        //    }
        //}

        //#endregion


        //        [HttpPost]
        //        [Route("AcceptRequest")]
        //        public async Task<ActionResult<RequestTbl>> AcceptRequest(
        //[FromBody] RequestTbl Model
        //)
        //        {
        //            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
        //            {
        //                return NotFound();
        //            }
        //            var req = await _requestRepository.AcceptRequest(Model);
        //            if (req == null)
        //            {
        //                return BadRequest();
        //            }
        //            return Ok();

        //        }


        //        [HttpPost]
        //        [Route("RejectRequest")]
        //        public async Task<ActionResult<RequestTbl>> RejectRequest(
        //[FromBody] RequestTbl Model
        //)
        //        {
        //            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
        //            {
        //                return NotFound();
        //            }
        //            var req = await _requestRepository.RejectRequest(Model);
        //            if (req == null)
        //            {
        //                return BadRequest();
        //            }
        //            return Ok();

        //        }





    }
}




