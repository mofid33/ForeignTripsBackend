using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace Foreign_Trips.Controllers
{
    [Route("api/Ticket")]
    public class TicketController :ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository, IMessageRepository messageRepository,
                                IMapper mapper)
        {
            _ticketRepository = ticketRepository ??
                throw new ArgumentNullException(nameof(ticketRepository));
            _messageRepository = messageRepository ??
                throw new ArgumentNullException(nameof(messageRepository));


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



        [HttpGet]
        [Route("GetTickets")]
        public async Task<ActionResult<TicketTbl>> GetTickets([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {

            var tickets = await _ticketRepository.GetTickets(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(tickets));

        }


        [HttpPost]
        [Route("GetTicketExpert")]

        public async Task<ActionResult<TicketTbl>> GetTicketExpert([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {

            var tickets = await _ticketRepository.GetTicketExpert(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(tickets));

        }


        [HttpPost]
        [Route("GetTicketAdmin")]


        public async Task<ActionResult<TicketTbl>> GetTicketAdmin([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {

            var tickets = await _ticketRepository.GetTicketAdmin(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(tickets));

        }

        [HttpGet]
        [Route("GetMainAdmin")]
        public async Task<ActionResult<TicketTbl>> GetTicketMainAdmin([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {

            var tickets = await _ticketRepository.GetTicketMainAdmin(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (tickets == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<MessageTbl>>(tickets));

        }


        [HttpPost]
        [Route("GetTicket")]
        public async Task<ActionResult<TicketTbl>> GetTicket(
       [FromBody] GetTicket Model
       )
        {

            var Tickets = await _ticketRepository.GetTicketAsync(Model.TicketID);
            if (Tickets == null)
            {
                return BadRequest();
            }
            return Ok(Tickets);

        }


        [HttpPost]
        [Route("GetSubTickets")]
        public async Task<ActionResult<TicketDetailsTbl>> GetSubTickets(
            [FromBody] TicketDetailsTbl Model
            )
        {

            var Tickets = await _ticketRepository.GetSubTickets(Model.TicketId);
            if (Tickets == null)
            {
                return BadRequest();
            }
            return Ok(
         _mapper.Map<IEnumerable<TicketDetailsTbl>>(Tickets)
         );

        }
    }
}
