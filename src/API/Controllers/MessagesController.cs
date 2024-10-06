namespace KafkaProducerSample.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        #region Properties
        private readonly IMessageService _messageService;

        #endregion

        #region Constructors

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        #endregion

        #region CRUD Methods

        /// <summary> Send Message to Kafka </summary>
        /// <param name="message"></param>
        [HttpPost()]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> SendMessageAsync([FromBody] string message)
        {

            await _messageService.SendMessageAsync(message);

            return Ok(message);
        }

        #endregion
    }
}
