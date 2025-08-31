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
    private readonly IInventoryMessageBus _messageBus;

    public InventoryManager(
        IMapper mapper,
        IInventoryRepository repository,
        IInventoryMessageBus messageBus)
        : base(mapper, repository)
    {
        _messageBus = messageBus;
    }

    public async Task<InventoryModel> Create(
        InventoryModel model,
        CancellationToken cancellationToken = default)
    {
        var createdItem = await base.Create(model, cancellationToken);

        await _messageBus.ProduceAsync(model, cancellationToken);

        return createdItem;
    }
}
