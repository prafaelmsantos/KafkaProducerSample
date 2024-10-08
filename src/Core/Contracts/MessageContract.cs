namespace KafkaProducerSample.Core.Contracts
{
    public class MessageContract : MessageBase, IKafkaMessageBase
    {
        public static string QueueName { get => "message_sample"; }
        public static string TopicName { get => "message_sample"; }
        public static int Partitions { get => 1; }
    }
}
