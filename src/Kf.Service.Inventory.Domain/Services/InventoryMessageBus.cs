using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryProducer
    : IInventoryProducer
{
    private readonly IProducer<string, string> _producer;

    private readonly string _topic;

    private readonly ILogger<InventoryProducer> _logger;

    public InventoryProducer(
        IConfiguration configuration,
        ILogger<InventoryProducer> logger)
    {
        _logger = logger;

        var config = new ProducerConfig
        {
            BootstrapServers = configuration.GetSection("Kafka:BootstrapServers")
                .Value,
            Acks = Acks.All,
            MessageTimeoutMs = 2000
        };

        _topic = configuration.GetSection("Kafka:Topic")
            .Value ?? throw new Exception("Not found Kafka Topic");
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task ProduceAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(message);

        var kafkaMessage = new Message<string, string> { Value = json };

        var deliveryResult = await _producer.ProduceAsync(_topic, kafkaMessage, cancellationToken);

        _logger.LogInformation("Message delivered to {DeliveryResultTopicPartitionOffset}",
            deliveryResult.TopicPartitionOffset);
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(5));
        _producer.Dispose();
    }
}
