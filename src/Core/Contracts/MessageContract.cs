namespace KafkaProducerSample.Core.Contracts
{
    public class MessageContract : MessageBase, IKafkaMessageBase
    {
        public static string QueueName { get => "message_sample"; }
        public static string TopicName { get => "message_sample"; }
        public static string GroupId { get => "message_sample_kafka_producer_sample"; }
    }
}
