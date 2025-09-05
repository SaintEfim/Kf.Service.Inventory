using AutoMapper;
using Kf.Service.Inventory.Domain.Models.Base.Kafka;
using Kf.Service.Inventory.Domain.Services.Base.Kafka.Handlers;
using Kf.Service.Inventory.Messages.Inventory;
using Kf.Service.Inventory.Messages.Models;
using Kf.Service.Warehouse.Messages.Warehouse;

namespace Kf.Service.Inventory.Domain.Services.MessageHandlers;

public class InventoryListRequestMessageHandler
    : MessageHandlerBase<WarehouseInventoryListRequestMessage>,
        IInventoryMessageHandler
{
    private readonly IMapper _mapper;

    private readonly IInventoryProvider _contractorProvider;

    private readonly IInventoryMessageBus _messageBus;

    public InventoryListRequestMessageHandler(
        IMapper mapper,
        IInventoryProvider contractorProvider,
        IInventoryMessageBus messageBus)
    {
        _mapper = mapper;
        _contractorProvider = contractorProvider;
        _messageBus = messageBus;
    }

    protected override async Task<MessageHandlingResult> Handle(
        WarehouseInventoryListRequestMessage message,
        CancellationToken cancellationToken = default)
    {
        var inventories = await _contractorProvider.Get(cancellationToken: cancellationToken);

        var answerMessage = new InventoryListMessage { Inventories = _mapper.Map<List<InventoryData>>(inventories) };

        await _messageBus.SendMessage(answerMessage, cancellationToken);

        return MessageHandlingResult.Succeeded;
    }
}
