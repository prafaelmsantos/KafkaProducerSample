namespace KafkaProducerSample.Persistence.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageToKafkaAsync(string content);
    }
}
