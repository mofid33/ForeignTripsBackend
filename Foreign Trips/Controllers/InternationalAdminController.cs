using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Admin")]
    public class InternationalAdminController : ControllerBase
    {
        private readonly IInternationalAdminRepository _internatinaladminRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IMainAdminRepository _mainadminRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IInternationalExpertRepository _internationalexpertRepository;
        private readonly IMapper _mapper;


        public InternationalAdminController(IInternationalAdminRepository internatinaladminRepository, IRequestRepository requestRepository,
                                            IReportRepository reportRepository, IAgentRepository agentRepository, ITicketRepository ticketRepository,
                                            ISupervisorRepository supervisorRepository, IAuthRepository authRepository, IMainAdminRepository mainadminRepository,
                                            IMessageRepository messageRepository, IInternationalExpertRepository internationalexpertRepository,
                                            IMapper mapper)
        {
            _internatinaladminRepository = internatinaladminRepository ??
                throw new ArgumentNullException(nameof(internatinaladminRepository));
            _requestRepository = _requestRepository ??
                    throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = _reportRepository ??
                    throw new ArgumentNullException(nameof(reportRepository));
            _authRepository = _authRepository ??
                    throw new ArgumentNullException(nameof(authRepository));
            _agentRepository = _agentRepository ??
                    throw new ArgumentNullException(nameof(agentRepository));
            _ticketRepository = ticketRepository ??
                    throw new ArgumentNullException(nameof(ticketRepository));
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
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents()
        {
            var Agents = await _internatinaladminRepository.GetUser();

            return Ok(
                Agents
                );
        }
       


        [HttpPost]
        [Route("GetUserLog")]
        public async Task<ActionResult<LoginTbl>> GetUserLog(
[FromBody] LoginTbl Model
)
        {

            var logUser = await _internatinaladminRepository.GetUserLog(Model);
            if (logUser == null)
            {
                return BadRequest();
            }
            return Ok(
                  _mapper.Map<LoginTbl>(logUser)
                  );
        }



      
        [HttpPost]
        [Route("InsertInternationalAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> InsertAdmin(
    [FromBody] InternationalAdminTbl Model
    )
        {

            var EAgent = await _internatinaladminRepository.InsertAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
            return Ok();

        }




        [HttpPost]
        [Route("UpdateInternationalAdmin")]
        public async Task<ActionResult<InternationalAdminTbl>> UpdateAdmin(
[FromBody] InternationalAdminTbl Model
)
        {
            if (!await _internatinaladminRepository.AdminExistsAsync(Model.AdminId))
            {
                return NotFound();
            }
            var EAgent = await _internatinaladminRepository.UpdateAdmin(Model);
            if (EAgent == null)
            {
                return BadRequest();
            }
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
                if (!await _internatinaladminRepository.AdminExistsAsync(Model.AdminId))
                {
                    return NoContent();
                }
                _internatinaladminRepository.RemoveAdmin(Model.AdminId);

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
        public async Task<ActionResult<IEnumerable<SupervisorTbl>>> GetSupervisor()
        {
            var sup = await _supervisorRepository.GetSupervisor();

            return Ok(
                sup
                );
        }

        [HttpPost]
        [Route("InsertSupervisor")]
        public async Task<ActionResult<SupervisorTbl>> InsertSupervisor(
[FromBody] SupervisorTbl Model
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
        public async Task<ActionResult<IEnumerable<InternationalExpertTbl>>> GetInternationalExpert()
        {
            var interexpert = await _internationalexpertRepository.GetInternationalExpert();

            return Ok(
                interexpert
                );
        }





        [HttpPost]
        [Route("InsertInternationalExpert")]
        public async Task<ActionResult<InternationalExpertTbl>> InsertInternationalExpert(
    [FromBody] InternationalExpertTbl Model
    )
        {

            var Inter = await _internationalexpertRepository.InsertInternationalExpert(Model);
            if (Inter == null)
            {
                return BadRequest();
            }
            return Ok();

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

        #endregion

        #region Agent
        [HttpGet]
        [Route("GetAgent")]
        public async Task<ActionResult<AgentTbl>> GetAgent(
[FromBody] AgentTbl Model
)
        {

            var agent = await _mainadminRepository.GetAgent(Model.AgentId);
            return Ok(
         _mapper.Map<RequestTbl>(agent)
         );

        }

        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentTbl>> InsertAgnet(
        [FromBody] AgentTbl Model
        )
        {

            var Sup = await _agentRepository.InsertAgentAsync(Model);
            if (Sup == null)
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
            var agent = await _agentRepository.UpdateAgentAsync(Model);
            if (agent == null)
            {
                return BadRequest();
            }
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

            var messages = await _messageRepository.GetMessage(Model.MessageId);
            return Ok(messages);

        }
        #endregion

         #region Log
        [HttpPost]
        [Route("GetUserLog")]
        public async Task<ActionResult<LoginTbl>> GetUserLog(
[FromBody] LoginTbl Model
)
        {

            var logUser = await _internatinaladminRepository.GetUserLog(Model);
            if (logUser == null)
            {
                return BadRequest();
            }
            return Ok(
                  _mapper.Map<LoginTbl>(logUser)
                  );
        }

        #endregion

       

    }
}
