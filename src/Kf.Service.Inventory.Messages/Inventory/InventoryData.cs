namespace Kf.Service.Inventory.Messages.Inventory;

public class InventoryData
{
    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required int Quantity { get; set; }
}
