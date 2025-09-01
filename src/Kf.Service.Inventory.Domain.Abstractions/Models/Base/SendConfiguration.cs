namespace Kf.Service.Inventory.Domain.Models.Base;

public class SendConfiguration
{
    public string Topic { get; set; } = string.Empty;

    public int MessageTimeoutMs { get; set; }
}
