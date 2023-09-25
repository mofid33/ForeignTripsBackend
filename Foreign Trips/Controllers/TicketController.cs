using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Ticket")]
    public class TicketController :ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository,
                                IMapper mapper)
        {
            _ticketRepository = ticketRepository ??
                throw new ArgumentNullException(nameof(ticketRepository));


            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        [Route("InsertTicket")]
        public async Task<ActionResult<TicketTbl>> InsertTicket(
[FromBody] TicketTbl Model
)
        {

            var Ticket = await _ticketRepository.InsertTicket(Model);
            if (Ticket == null)
            {
                return BadRequest();
            }
            return Ok(Ticket);

        }

        [HttpPost]
        [Route("InsertSubTicket")]
        public async Task<ActionResult<TicketDetailsTbl>> InsertSubTicket(
[FromBody] TicketDetailsTbl Model
)
        {
            if (!await _ticketRepository.TicketExistsAsync(Model.TicketId))
            {
                return NotFound();
            }

            var Tickets = await _ticketRepository.InsertSubTicket(Model);
            if (Tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<TicketDetailsTbl>(Tickets));
        }


        [HttpPost]
        [Route("InsertSubTicketExpertToAgent")]
        public async Task<ActionResult<TicketDetailsDto>> InsertSubTicketExpertToAgent(
[FromBody] TicketDetailsDto Model
)
        {
            if (!await _ticketRepository.TicketExistsAsync(Model.TicketId))
            {
                return NotFound();
            }

            var Tickets = await _ticketRepository.InsertSubTicketExpertToAgent(Model);
            if (Tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<TicketDetailsDto>(Tickets));
        }


        [HttpPost]
        [Route("InsertSubTicketExpertAdmin")]
        public async Task<ActionResult<TicketDetailsTbl>> InsertSubTicketExpertAdmin(
[FromBody] TicketDetailsTbl Model
)
        {
            if (!await _ticketRepository.TicketExistsAsync(Model.TicketId))
            {
                return NotFound();
            }

            var Tickets = await _ticketRepository.InsertSubTicketExpertAdmin(Model);
            if (Tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<TicketDetailsTbl>(Tickets));
        }


        [HttpPost]
        [Route("InsertTicketExpertToAdmin")]
        public async Task<ActionResult<TicketTbl>> InsertTicketExpertToAdmin(
[FromBody] TicketTbl Model
)
        {

            var Ticket = await _ticketRepository.InsertTicketExpertToAdmin(Model);
            if (Ticket == null)
            {
                return BadRequest();
            }
            return Ok(Ticket);

        }



        [HttpPost]
        [Route("GetTickets")]
        public async Task<ActionResult<TicketTbl>> GetTickets([FromBody] GetTicket Model)
        {

            var Tickets = await _ticketRepository.GetTickets(Model.AgentID);

            return Ok(_mapper.Map<IEnumerable<TicketTbl>>(Tickets));

        }


        [HttpPost]
        [Route("GetTicketExpert")]
        public async Task<ActionResult<TicketTbl>> GetTicketExpert([FromBody] TicketTbl Model)
        {

            var Tickets = await _ticketRepository.GetTicketExpert(Convert.ToInt32(Model.InternationalExpertId));

            return Ok(_mapper.Map<IEnumerable<TicketTbl>>(Tickets));

        }


        [HttpPost]
        [Route("GetTicketAdmin")]
        public async Task<ActionResult<TicketTbl>> GetTicketAdmin([FromBody] TicketTbl Model)
        {

            var Tickets = await _ticketRepository.GetTicketExpert(Convert.ToInt32(Model.AdminId));

            return Ok(_mapper.Map<IEnumerable<TicketTbl>>(Tickets));

        }

        [HttpGet]
        [Route("GetMainAdmin")]
        public async Task<ActionResult<IEnumerable<TicketTbl>>> GetTicketMainAdmin()
        {
            var MainAdmin = await _ticketRepository.GetTicketMainAdmin();

            return Ok(
                MainAdmin
                );
        }


        [HttpPost]
        [Route("GetTicket")]
        public async Task<ActionResult<TicketTbl>> GetTicket(
       [FromBody] GetTicket Model
       )
        {

            var Tickets = await _ticketRepository.GetTicketAsync(Model.TicketID);
            return Ok(Tickets);

        }


        [HttpPost]
        [Route("GetSubTickets")]
        public async Task<ActionResult<TicketDetailsTbl>> GetSubTickets(
            [FromBody] TicketDetailsTbl Model
            )
        {

            var Tickets = await _ticketRepository.GetSubTickets(Model.TicketId);
            return Ok(
         _mapper.Map<IEnumerable<TicketDetailsTbl>>(Tickets)
         );

        }
    }
}
