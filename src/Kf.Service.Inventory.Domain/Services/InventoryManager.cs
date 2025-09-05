using AutoMapper;
using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Data.Repositories;
using Kf.Service.Inventory.Domain.Models;
using Kf.Service.Inventory.Domain.Services.Base;
using Kf.Service.Inventory.Messages.Inventory;
using Kf.Service.Inventory.Messages.Models;

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

    public override async Task<InventoryModel> Create(
        InventoryModel model,
        CancellationToken cancellationToken = default)
    {
        var createdItem = await base.Create(model, cancellationToken);

        var inventoryCreate = new InventoryCreatedMessage { Inventory = Mapper.Map<InventoryData>(createdItem) };

        await _messageBus.SendMessage(inventoryCreate, cancellationToken);

        return createdItem;
    }

    public override async Task<InventoryModel> Update(
        InventoryModel model,
        CancellationToken cancellationToken = default)
    {
        var updatedItem = await base.Update(model, cancellationToken);

        var inventoryUpdate = new InventoryUpdatedMessage { Inventory = Mapper.Map<InventoryData>(updatedItem) };

        await _messageBus.SendMessage(inventoryUpdate, cancellationToken);

        return updatedItem;
    }

    public override async Task<InventoryModel> Delete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var deletedItem = await base.Delete(id, cancellationToken);

        var inventoryDelete = new InventoryDeletedMessage { Inventory = Mapper.Map<InventoryData>(deletedItem) };

        await _messageBus.SendMessage(inventoryDelete, cancellationToken);

        return deletedItem;
    }
}
