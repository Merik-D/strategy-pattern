using Confluent.Kafka;

namespace strategy_pattern;

public class KafkaOutputStrategy : IOutputStrategy
{
    private readonly string _topic;
    private readonly IProducer<Null, string> _producer;

    public KafkaOutputStrategy(string topic)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        _producer = new ProducerBuilder<Null, string>(config).Build();
        _topic = topic;
    }

    public void Write(string data)
    {
        _producer.Produce(_topic, new Message<Null, string> { Value = data }, deliveryReport =>
        {
            if (deliveryReport.Error.IsError)
                Console.WriteLine($"Kafka Error: {deliveryReport.Error.Reason}");
            else
                Console.WriteLine($"Published to Kafka topic '{_topic}': {data}");
        });
        _producer.Flush(TimeSpan.FromSeconds(5));
    }
}