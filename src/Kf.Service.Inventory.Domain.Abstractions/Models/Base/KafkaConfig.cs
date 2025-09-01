namespace Kf.Service.Inventory.Domain.Models.Base;

public class KafkaConfig
{
    public string BootstrapServers { get; set; } = string.Empty;

    public Handle Handle { get; set; } = null!;

    public Send Send { get; set; } = null!;
}
