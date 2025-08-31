namespace Kf.Service.Inventory.Domain.Models.Base;

public class KafkaSendConfig
{
    public string Topic { get; set; } = string.Empty;

    public int MessageTimeoutMs { get; set; }
}
