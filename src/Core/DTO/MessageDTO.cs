namespace KafkaProducerSample.Core.DTO
{
    public class MessageDTO
    {
        public long Id { get; set; }
        public required string Message { get; set; }
    }
}
