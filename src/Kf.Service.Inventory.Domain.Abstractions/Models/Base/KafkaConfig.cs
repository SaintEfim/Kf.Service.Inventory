namespace Kf.Service.Inventory.Domain.Models.Base;

public class KafkaConfig
{
    public string BootstrapServers { get; set; } = string.Empty;

    public HandleConfiguration HandleConfiguration { get; set; } = null!;

    public SendConfiguration SendConfiguration { get; set; } = null!;
}
