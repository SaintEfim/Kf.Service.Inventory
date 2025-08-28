using AutoMapper;
using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Data.Repositories;
using Kf.Service.Inventory.Domain.Models;
using Kf.Service.Inventory.Domain.Services.Base;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryProvider
    : DataProviderBase<InventoryModel, InventoryEntity, IInventoryRepository>,
        IInventoryProvider
{
    public InventoryProvider(
        IMapper mapper,
        IInventoryRepository repository)
        : base(mapper, repository)
    {
    }
}
