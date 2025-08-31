using Confluent.Kafka;
using Kf.Service.Inventory.Domain.Models.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryMessageBus : IInventoryMessageBus
{
    private readonly IProducer<string, string> _producer;

    private readonly string _topic;

    private readonly ILogger<InventoryMessageBus> _logger;

    /* public InventoryMessageBus(
        ILogger<InventoryMessageBus> logger,
        IOptions<KafkaConfig> kafkaConfig)
    {
        _logger = logger;

        var config = new ProducerConfig
        {
            BootstrapServers = kafkaConfig.Value.BootstrapServers,
            MessageTimeoutMs = kafkaConfig.Value.KafkaHandleConfig.MessageTimeoutMs
        };

        _topic = kafkaConfig.Value.KafkaHandleConfig.Topic ?? throw new Exception("Not found Kafka Topic");
        _producer = new ProducerBuilder<string, string>(config).Build();
    } */

    public InventoryMessageBus(
        IConfiguration configuration,
        ILogger<InventoryMessageBus> logger)
    {
        _logger = logger;

        var config = new ProducerConfig
        {
            BootstrapServers = configuration.GetSection("Kafka:BootstrapServers")
                .Value,
            Acks = Acks.All
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
