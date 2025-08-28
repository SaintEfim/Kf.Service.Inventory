using AutoMapper;
using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Data.Repositories;
using Kf.Service.Inventory.Domain.Models;
using Kf.Service.Inventory.Domain.Services.Base;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryManager
    : DataManagerBase<InventoryModel, InventoryEntity, IInventoryRepository>,
        IInventoryManager
{
    public InventoryManager(
        IMapper mapper,
        IInventoryRepository repository)
        : base(mapper, repository)
    {
    }
}
