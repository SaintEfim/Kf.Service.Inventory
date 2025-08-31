namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IMessageBus
{
    Task ProduceAsync<T>(
        T message,
        CancellationToken cancellationToken = default);
}
