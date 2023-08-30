using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Message")]
    public class MessageController: ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageController(IMessageRepository messageRepository,
                                IMapper mapper)
        {
            _messageRepository = messageRepository ??
                throw new ArgumentNullException(nameof(messageRepository));


            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

    }
}

    
