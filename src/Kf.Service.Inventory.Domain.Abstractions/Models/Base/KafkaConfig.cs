namespace Kf.Service.Inventory.Domain.Models.Base;

public class KafkaConfig
{
    public string BootstrapServers { get; set; } = string.Empty;

    public KafkaHandleConfig KafkaHandleConfig { get; set; } = null!;

    public KafkaSendConfig KafkaSendConfig { get; set; } = null!;
}
