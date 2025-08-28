using Kf.Service.Inventory.Domain.Models.Base;

namespace Kf.Service.Inventory.Domain.Models;

public class InventoryModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Category { get; set; } = string.Empty;

    public string Supplier { get; set; } = string.Empty;
}
