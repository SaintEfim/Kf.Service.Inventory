namespace Kf.Service.Inventory.Domain.Services.Base.Kafka;

public interface IInventoryMessageBus
    : IMessageBus,
        IDisposable;
