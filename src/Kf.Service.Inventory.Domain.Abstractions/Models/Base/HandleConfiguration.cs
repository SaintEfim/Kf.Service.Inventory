namespace Kf.Service.Inventory.Domain.Models.Base;

public class HandleConfiguration
{
    public string Topic { get; set; } = string.Empty;

    public int MessageTimeoutMs { get; set; }

    public string GroupId { get; set; } = string.Empty;

    public bool Disabled { get; set; }
}
