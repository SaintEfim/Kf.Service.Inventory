using Kf.Service.Inventory.Domain.Services.Base.Kafka;

namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IInventoryMessageBus
    : IMessageBus,
        IDisposable;
