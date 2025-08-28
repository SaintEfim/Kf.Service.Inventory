using System.ComponentModel.DataAnnotations;

namespace Kf.Service.Inventory.API.Models.Base;

public class CreateActionResultDto : IDto
{
    [Required]
    public Guid Id { get; set; }
}
