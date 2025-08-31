using Kf.Service.Inventory.Domain.Services.Base;

namespace Kf.Service.Inventory.Domain.Services;

public interface IInventoryProducer
    : IProducer,
        IDisposable;
