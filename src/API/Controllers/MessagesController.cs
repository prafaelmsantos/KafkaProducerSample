namespace KafkaProducerSample.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        #region Private vars
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
        /// <param name="content"></param>
        [HttpPost()]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> SendMessageToKafkaAsync([FromBody] string content)
        {

            await _messageService.SendMessageToKafkaAsync(content);

            return Ok(content);
        }

        #endregion
    }
}
