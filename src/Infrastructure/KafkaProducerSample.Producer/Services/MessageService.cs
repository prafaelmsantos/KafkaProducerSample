namespace KafkaProducerSample.Producer.Services
{
    public class MessageService : IMessageService
    {
        #region Private vars
        private readonly ILogger<IMessageService> _logger;
        private readonly IKafkaProducer _kafkaProducer;
        #endregion

        public MessageService(ILogger<IMessageService> logger, IKafkaProducer kafkaProducer)
        {
            _logger = logger;
            _kafkaProducer = kafkaProducer;
        }

        public async Task SendMessageAsync(string message)
        {
            Random random = new();
            MessageContract messageContract = new()
            {
                Id = random.NextInt64(1, long.MaxValue),
                Message = message
            };

            _ = await _kafkaProducer.ProduceMessageAsync(messageContract);

            _logger.LogInformation($"Created message with id {messageContract.Id}");
        }
    }
}
