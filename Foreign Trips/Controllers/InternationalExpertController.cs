using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/InternationalExpert")]
    public class InternationalExpertController : ControllerBase
    {
        private readonly IInternationalExpertRepository _internationalexpertRepository;
        private readonly IInternationalAdminRepository _internationaladminRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;


        public InternationalExpertController(IInternationalExpertRepository internationalexpertRepository, IMessageRepository messageRepository , IInternationalAdminRepository internationaladminRepository,
                                             IRequestRepository requestRepository, IReportRepository reportRepository, IMapper mapper)

        {
            _internationalexpertRepository = internationalexpertRepository ??
                throw new ArgumentNullException(nameof(internationalexpertRepository));
            _internationaladminRepository = internationaladminRepository ??
                throw new ArgumentNullException(nameof(internationaladminRepository));
            _messageRepository = messageRepository ??
                throw new ArgumentNullException(nameof(messageRepository));
            _requestRepository = requestRepository ??
                throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = reportRepository ??
                throw new ArgumentNullException(nameof(reportRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetInternationalExpert")]
        public async Task<ActionResult<IEnumerable<InternationalExpertTbl>>> GetInternationalExpert()
        {
            var interexpert = await _internationalexpertRepository.GetInternationalExpert();

            return Ok(
                interexpert
                );
        }

        [HttpPost]
        [Route("GetInternationalExpertByID")]
        public async Task<ActionResult<InternationalExpertTbl>> GetInternationalExpertByID(
     [FromBody] InternationalExpertTbl Model
     )
        {

            var intexpert = await _internationalexpertRepository.GetInternationalExpertAsync(Model.InternationalExpertId);
            return Ok(
         _mapper.Map<InternationalExpertTbl>(intexpert)
         );

        }




        [HttpPost]
        [Route("InsertInternationalExpert")]
        public async Task<ActionResult<InternationalExpertDto>> InsertInternationalExpert(
    [FromBody] InternationalExpertDto Model
    )
        {

            var Inter = await _internationalexpertRepository.InsertInternationalExpert(Model);
            if (Inter == null)
            {
                return BadRequest();
            }
            return Ok(Inter);

        }




        [HttpPost]
        [Route("UpdateInternationalExpert")]
        public async Task<ActionResult<InternationalExpertTbl>> UpdateInternationalExpert(
[FromBody] InternationalExpertTbl Model
)
        {
            if (!await _internationalexpertRepository.InternationalExpertExistsAsync(Model.InternationalExpertId))
            {
                return NotFound();
            }
            var Inter = await _internationalexpertRepository.UpdateInternationalExpert(Model);
            if (Inter == null)
            {
                return BadRequest();
            }
            return Ok();
        }




        [HttpPost]
        [Route("RemoveInternationalExpert")]
        public async Task<ActionResult<InternationalExpertTbl>> RemoveInternationalExpert(
[FromBody] InternationalExpertTbl Model
)
        {
            try
            {
                if (!await _internationalexpertRepository.InternationalExpertExistsAsync(Model.InternationalExpertId))
                {
                    return NoContent();
                }
                _internationalexpertRepository.RemoveInternationalExpert(Model.InternationalExpertId);

                return Ok();
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        #region Message

        [HttpGet]
        [Route("GetMessages")]
        public async Task<ActionResult<MessageTbl>> GetMessage()
        {

            var messages = await _messageRepository.GetMessage();

            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(messages));

        }

        [HttpPost]
        [Route("GetMessage")]
        public async Task<ActionResult<MessageTbl>> GetMessage(
       [FromBody] MessageTbl Model
       )
        {

            var messages = await _messageRepository.GetMessageAsync(Model.MessageId);
            return Ok(messages);

        }

        [HttpPost]
        [Route("InsertMessage")]
        public async Task<ActionResult<MessageTbl>> InsertMessage(
[FromBody] MessageTbl Model
)
        {

            var message = await _messageRepository.InsertMessage(Model);
            if (message == null)
            {
                return BadRequest();
            }
            return Ok(message);

        }

        #endregion

        #region Request
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
        [Route("AcceptRequest")]
        public async Task<ActionResult<RequestTbl>> AcceptRequest(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            var req = await _requestRepository.AcceptRequestExpert(Model);
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
            var req = await _requestRepository.RejectRequestExpert(Model);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok();

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
                await _internationalexpertRepository.PostFileAsync(fileDetails);
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
                await _internationalexpertRepository.PostMultiFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Report
        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<IEnumerable<ReportTbl>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();

            return Ok(
                reports
                );
        }

        [HttpPost]
        [Route("GetReport")]
        public async Task<ActionResult<ReportTbl>> GetReport(
     [FromBody] ReportTbl Model
     )
        {

            var rep = await _reportRepository.GetReportAsync(Model.ReportId);
            return Ok(
         _mapper.Map<ReportTbl>(rep)
         );

        }

        [HttpPost]
        [Route("AcceptReportExpert")]
        public async Task<ActionResult<RequestTbl>> AcceptReportExpert(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            var req = await _requestRepository.AcceptReportExpert(Model);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok();

        }



        [HttpPost]
        [Route("RejectReportExpert")]
        public async Task<ActionResult<RequestTbl>> RejectReportExpert(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }
            var req = await _requestRepository.RejectReportExpert(Model);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok();

        }
        #endregion


        #region Admin

        [HttpGet]
        [Route("GetInternationalAdmin")]
        public async Task<ActionResult<IEnumerable<InternationalAdminTbl>>> GetAdmin()
        {
            var Int = await _internationaladminRepository.GetAdmins();

            return Ok(
                _mapper.Map<IEnumerable<InternationalAdminTbl>>(Int)
                );
        }

        #endregion

    }
}
