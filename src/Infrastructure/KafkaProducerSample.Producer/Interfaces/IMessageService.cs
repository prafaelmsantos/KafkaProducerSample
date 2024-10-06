namespace KafkaProducerSample.Producer.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(string message);
    }
}
