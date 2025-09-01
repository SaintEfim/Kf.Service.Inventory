using Confluent.Kafka;
using Kf.Service.Inventory.Domain.Models.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kf.Service.Inventory.Domain.Services.Base;

public abstract class KafkaMessageBusBase<TMessageBus>
    : IMessageBus,
        IDisposable
    where TMessageBus : class, IMessageBus
{
    private readonly IProducer<string, string> _producer;
    private readonly IOptions<KafkaConfig> _configKafka;
    private readonly ILogger _logger;

    protected KafkaMessageBusBase(
        IOptions<KafkaConfig> configKafka,
        ILogger<TMessageBus> logger)
    {
        _configKafka = configKafka;
        _logger = logger;
        _producer = CreateProducer(configKafka);
    }

    public async Task ProduceAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(message);
        var kafkaMessage = new Message<string, string> { Value = json };

        var deliveryResult = await _producer.ProduceAsync(_configKafka.Value.SendConfiguration.Topic, kafkaMessage,
            cancellationToken);

        _logger.LogInformation("Message delivered to {DeliveryResultTopicPartitionOffset}",
            deliveryResult.TopicPartitionOffset);
    }

    private IProducer<string, string> CreateProducer(
        IOptions<KafkaConfig> configKafka)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = configKafka.Value.BootstrapServers,
            MessageTimeoutMs = configKafka.Value.SendConfiguration.MessageTimeoutMs
        };

        return new ProducerBuilder<string, string>(config).SetLogHandler(ProducerLogHandler)
            .Build();
    }

    private void ProducerLogHandler(
        IProducer<string, string> producer,
        LogMessage logMessage)
    {
        _logger.Log((LogLevel) logMessage.LevelAs(LogLevelType.MicrosoftExtensionsLogging),
            "{KafkaInstance}|{Facility}|{Message}", logMessage.Name, logMessage.Facility, logMessage.Message);
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(5));
        _producer.Dispose();
    }
}
