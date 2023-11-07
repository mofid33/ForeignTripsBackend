using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/InternationalAdmin")]
    public class InternationalAdminController : ControllerBase
    {
        private readonly IInternationalAdminRepository _internationaladminRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IMainAdminRepository _mainadminRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IInternationalExpertRepository _internationalexpertRepository;
        private readonly IMapper _mapper;


        public InternationalAdminController(IInternationalAdminRepository internationaladminRepository, IRequestRepository requestRepository,
                                            IReportRepository reportRepository, IAgentRepository agentRepository,
                                            ISupervisorRepository supervisorRepository, IAuthRepository authRepository, IMainAdminRepository mainadminRepository,
                                            IMessageRepository messageRepository, IInternationalExpertRepository internationalexpertRepository,
                                            IMapper mapper)
        {
            _internationaladminRepository = internationaladminRepository ??
                throw new ArgumentNullException(nameof(internationaladminRepository));
            _requestRepository = requestRepository ??
                    throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = reportRepository ??
                    throw new ArgumentNullException(nameof(reportRepository));
            _authRepository =authRepository ??
                    throw new ArgumentNullException(nameof(authRepository));
            _agentRepository = agentRepository ??
                    throw new ArgumentNullException(nameof(agentRepository));
            _supervisorRepository = supervisorRepository ??
                    throw new ArgumentNullException(nameof(supervisorRepository));
            _mainadminRepository = mainadminRepository ??
                   throw new ArgumentNullException(nameof(mainadminRepository));
            _messageRepository = messageRepository ??
                   throw new ArgumentNullException(nameof(messageRepository));
            _internationalexpertRepository = internationalexpertRepository ??
               throw new ArgumentNullException(nameof(internationalexpertRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetInternationalAdmin")]
        public async Task<ActionResult<IEnumerable<InternationalAdminTbl>>> GetAdmin()
        {
            var Int = await _internationaladminRepository.GetAdmins();

            return Ok(
                _mapper.Map<IEnumerable<InternationalAdminTbl>>(Int)
                );
        }



        [HttpPost]
        [Route("InsertInternationalAdmin")]
        public async Task<ActionResult<InternationalAdminDto>> InsertAdmin(
    [FromBody] InternationalAdminDto Model
    )
        {

            var EAgent = await _internationaladminRepository.InsertAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok(EAgent);

        }




        [HttpPost]
        [Route("UpdateInternationalAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> UpdateAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            if (!await _internationaladminRepository.AdminExistsAsync(Model.AdminId))
            {
                return NoContent();
            }
            _internationaladminRepository.UpdateAdmin(Model);

            return Ok();
        }




        [HttpPost]
        [Route("RemoveInternationalAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> RemoveAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            try
            {
                if (!await _internationaladminRepository.AdminExistsAsync(Model.AdminId))
                {
                    return NoContent();
                }
                _internationaladminRepository.RemoveAdmin(Model.AdminId);

                return Ok();
            }
            
                 catch (System.Exception ex)
            {
                return null;

            }
        }


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
        [Route("InsertSupervisor")]
        public async Task<ActionResult<SupervisorDto>> InsertSupervisor(
[FromBody] SupervisorDto Model
)
        {

            var sup = await _supervisorRepository.InsertSupervisor(Model);
            if (sup == null)
            {
                return BadRequest();
            }
            return Ok(sup);

        }

        [HttpPost]
        [Route("UpdateSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> UpdateSupervisorAsync(
[FromBody] SupervisorTbl Model
)
        {
            var sup = await _supervisorRepository.UpdateSupervisorAsync(Model);
            if (sup == null)
            {
                return BadRequest();
            }
            return Ok();

        }

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

        #endregion

        #region Agent

        [HttpGet]
        [Route("GetAgents")]

        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, String search)
        {
            var Agents = await _agentRepository.GetAgent(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);

            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Agents
                );
        }

        [HttpPost]
        [Route("GetAgentById")]
        public async Task<ActionResult<AgentDto>> GetAgentById(
    [FromBody] AgentDto Model
    )
        {

            var Eagent = await _agentRepository.GetAgentAsync(Model.AgentId);
            if (Eagent == null)
            {
                return BadRequest();
            }

            return Ok(Eagent);

        }
        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentDto>> InsertAgnet(
       [FromBody] AgentDto Model
       )
        {

            var Eagent = await _agentRepository.InsertAgentAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }

            return Ok();

        }



        [HttpPost]
        [Route("UpdateAgnet")]
        public async Task<ActionResult<AgentTbl>> UpdateAgentAsync(
[FromBody] AgentTbl Model
)
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
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

        [HttpPost]
        [Route("SuspendAgent")]
        public async Task<ActionResult<AgentTbl>> SuspendAgent(
[FromBody] GetAgent Model
)
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NotFound();
            }
            await _agentRepository.SuspendAgentAsync(Model.AgentId);

            return Ok();

        }


        #endregion

        #region Message

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
            var req = await _requestRepository.AcceptRequestAdmin(Model);
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
            var req = await _requestRepository.RejectRequestAdmin(Model);
            if (req == null)
            {
                return BadRequest();
            }
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

        #region Excel
        [HttpGet]
        [Route("GetExcel")]
        public async Task<ActionResult<LoginTbl>> GetExcel()
        {

            var path = await _internationaladminRepository.GetExcelAgent();
            if (path == null)
            {
                return BadRequest();
            }

            return Ok(path);
        }

        //[HttpPost]
        //[Route("GetExcelLogin")]
        //public async Task<ActionResult<LoginTbl>> GetExcelLogin([FromBody] LoginTbl Model)
        //{

        //    var path = await _internationaladminRepository.GetExcelLogin(Model);
        //    if (path == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(path);
        //}

        #endregion



    }
}
