using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using static NPOI.HSSF.Util.HSSFColor;

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
        private readonly IMainAdminRepository _mainadminRepository;
        private readonly IMapper _mapper;


        public InternationalExpertController(IInternationalExpertRepository internationalexpertRepository, IMessageRepository messageRepository, IInternationalAdminRepository internationaladminRepository,
                                             IRequestRepository requestRepository, IReportRepository reportRepository, IMainAdminRepository mainadminRepository, IMapper mapper)

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
            _mainadminRepository = mainadminRepository ??
                throw new ArgumentNullException(nameof(mainadminRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetInternationalExpert")]
        public async Task<ActionResult<IEnumerable<InternationalExpertTbl>>> GetInternationalExpert([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var interexpert = await _internationalexpertRepository.GetInternationalExpert(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (interexpert == null)
            {
                return BadRequest();
            }
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
            if (intexpert == null)
            {
                return BadRequest();
            }
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
                return NoContent();
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
                var exp = await _internationalexpertRepository.RemoveInternationalExpert(Model.InternationalExpertId);
                if (exp == null)
                {
                    return BadRequest();
                }

                return Ok(exp);
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        #region Message

        [HttpGet]
        [Route("GetMessages")]
        public async Task<ActionResult<MessageTbl>> GetMessage([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {

            var messages = await _messageRepository.GetMessage(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);

            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(messages));

        }

        [HttpPost]
        [Route("GetMessage")]
        public async Task<ActionResult<MessageTbl>> GetMessage(
       [FromBody] MessageTbl Model
       )
        {

            var messages = await _messageRepository.GetMessageAsync(Model.MessageId);
            if (messages == null)
            {
                return BadRequest();
            }
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
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var Requests = await _requestRepository.GetRequest(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);

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
        public async Task<ActionResult> PostSingleFile([FromForm] PhotoUploadModel fileDetails)
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
        public async Task<ActionResult> PostMultipleFile([FromForm] List<PhotoUploadModel> fileDetails)
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

        #region MainAdmin
        [HttpGet]
        [Route("GetMainAdmin")]

        public async Task<ActionResult<IEnumerable<MainAdminTbl>>> GetMainAdmin([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)

        {
            var Admin = await _mainadminRepository.GetMainAdmin(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (Admin == null)
            {
                return BadRequest();
            }
            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Admin
                );
        }
        #endregion

        #region Admin
        [HttpGet]
        [Route("GetInternationalAdmins")]

        public async Task<ActionResult<InternationalAdminTbl>> GetAdmins(
        [FromBody] InternationalAdminTbl Model
        )
        {

            var Int = await _internationaladminRepository.GetAdmins(Model.AdminId);
            if (Int == null)
            {
                return BadRequest();
            }

            return Ok(
         _mapper.Map<SupervisorTbl>(Int)
         );

            #endregion

        }
    }
 }
