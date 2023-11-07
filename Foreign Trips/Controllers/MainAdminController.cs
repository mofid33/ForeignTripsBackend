using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Foreign_Trips.Controllers
{
    [Route("api/MainAdmin")]
    public class MainAdminController: ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMainAdminRepository _mainadminRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IInternationalAdminRepository _internatinaladminRepository;
        private readonly IReportRepository _reportRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IInternationalExpertRepository _internationalexpertRepository;
        private readonly IMapper _mapper;
        public MainAdminController(IAgentRepository agentRepository, IMainAdminRepository mainadminRepository, IAuthRepository authRepository,
                                   IInternationalAdminRepository internatinaladminRepository, IReportRepository reportRepository,
                                   ISupervisorRepository supervisorRepository, IMessageRepository messageRepository,
                                   IRequestRepository requestRepository, IInternationalExpertRepository internationalexpertRepository,
                                   IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _mainadminRepository = mainadminRepository ??
               throw new ArgumentNullException(nameof(mainadminRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
            _internatinaladminRepository = internatinaladminRepository ??
               throw new ArgumentNullException(nameof(internatinaladminRepository));
            _reportRepository = reportRepository ??
               throw new ArgumentNullException(nameof(reportRepository));
            _supervisorRepository = supervisorRepository ??
               throw new ArgumentNullException(nameof(supervisorRepository));
            _messageRepository = messageRepository ??
               throw new ArgumentNullException(nameof(messageRepository));
            _requestRepository = requestRepository ??
               throw new ArgumentNullException(nameof(requestRepository));
            _internationalexpertRepository = internationalexpertRepository ??
               throw new ArgumentNullException(nameof(internationalexpertRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("GetMainAdmin")]
        public async Task<ActionResult<IEnumerable<MainAdminTbl>>> GetMainadmin()
        {
            var mainadmin= await _mainadminRepository.GetMainAdmin();

            return Ok(
                mainadmin
                );
        }

        [HttpPost]
        [Route("GetMainAdmins")]
        public async Task<ActionResult<MainAdminTbl>> GetMainAdmins(
    [FromBody] MainAdminTbl Model
    )
        {

            var mainadmin = await _mainadminRepository.GetMainAdminAsync(Model.MainAdminId);
            return Ok(
         _mapper.Map<MainAdminTbl>(mainadmin)
         );

        }


        [HttpPost]
        [Route("InsertMainAdmin")]
        public async Task<ActionResult<MainAdminDto>> InsertMainAdmin(
[FromBody] MainAdminDto Model
)
        {

            var mainadmin = await _mainadminRepository.InsertMainAdmin(Model);
            if (mainadmin == null)
            {
                return BadRequest();
            }
            return Ok(mainadmin);

        }

        [HttpPost]
        [Route("UpdateMainAdmin")]
        public async Task<ActionResult<MainAdminTbl>> UpdateMainAdminAsync(
[FromBody] MainAdminTbl Model
)
        {
            if (!await _mainadminRepository.MainAdminExistsAsync(Model.MainAdminId))
            {
                return NoContent();
            }
            _mainadminRepository.UpdateMainAdminAsync(Model);

            return Ok();

        }

        #region Agent


        [HttpGet]
        [Route("GetAgents")]

        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var Agents = await _agentRepository.GetAgent(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);


            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Agents
                );
        }

        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentDto>> InsertAgnet(
        [FromBody] AgentDto Model
        )
        {

            var Sup = await _agentRepository.InsertAgentAsync(Model);
            if (Sup == null)
            {
                return BadRequest();
            }

            return Ok(Sup);

        }


        [HttpPost]
        [Route("UpdateAgnet")]
        public async Task<ActionResult<AgentTbl>> UpdateAgentAsync(
[FromBody] AgentTbl Model
)
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NoContent();
            }
            _agentRepository.UpdateAgentAsync(Model);

            return Ok();

        }


        [HttpPost]
        [Route("DeleteAgent")]
        public async Task<ActionResult<AgentTbl>> DeleteAgent(
        [FromBody] AgentTbl Model
        )
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            _agentRepository.DeleteAgent(Model.AgentId);

            return Ok();

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


        #endregion

        #region Supervisor

        [HttpGet]
        [Route("GetSupervisor")]
        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var sup = await _supervisorRepository.GetSupervisor(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);

            return Ok(
                sup
                );
        }

        [HttpPost]
        [Route("GetSupervisors")]
        public async Task<ActionResult<SupervisorTbl>> GetSupervisors(
             [FromBody] SupervisorTbl Model
             )
        {

            var sup = await _supervisorRepository.GetSupervisorAsync(Model.SupervisorId);
            return Ok(
         _mapper.Map<SupervisorTbl>(sup)
         );

        }

        //        [HttpPost]
        //        [Route("InsertSupervisor")]
        //        public async Task<ActionResult<SupervisorTbl>> InsertSupervisor(
        //[FromBody] SupervisorTbl Model
        //)
        //        {

        //            var sup = await _supervisorRepository.InsertSupervisor(Model);
        //            if (sup == null)
        //            {
        //                return BadRequest();
        //            }
        //            return Ok(sup);

        //        }

        //        [HttpPost]
        //        [Route("UpdateSupervisor")]
        //        public async Task<ActionResult<SupervisorTbl>> UpdateSupervisorAsync(
        //[FromBody] SupervisorTbl Model
        //)
        //        {
        //            var sup = await _supervisorRepository.UpdateSupervisorAsync(Model);
        //            if (sup == null)
        //            {
        //                return BadRequest();
        //            }
        //            return Ok();

        //        }

        [HttpPost]
        [Route("RemoveSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> RemoveSupervisorAsync(
       [FromBody] SupervisorTbl Model
       )
        {
            if (!await _supervisorRepository.SupervisorExistsAsync(Model.SupervisorId))
            {
                return NotFound();
            }
            _supervisorRepository.RemoveSupervisorAsync(Model.SupervisorId);

            return Ok();

        }


        #endregion

        #region InternationalExpert

        [HttpGet]
        [Route("GetInternationalExpert")]
        public async Task<ActionResult<IEnumerable<InternationalExpertTbl>>> GetInternationalExpert([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var interexpert = await _internationalexpertRepository.GetInternationalExpert(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);

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

            var req = await _internationalexpertRepository.GetInternationalExpertAsync(Model.InternationalExpertId);
            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }





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
        //                if (!await _internationalexpertRepository.InternationalExpertExistsAsync(Model.InternationalExpertId))
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

        #endregion

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
            var req = await _requestRepository.AcceptRequestMainAdmin(Model);
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
            var req = await _requestRepository.RejectRequestMainAdmin(Model);
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


    }
}
