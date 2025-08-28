using System.ComponentModel.DataAnnotations;

namespace Kf.Service.Inventory.API.Models;

public class InventoryCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Supplier { get; set; } = string.Empty;
}
