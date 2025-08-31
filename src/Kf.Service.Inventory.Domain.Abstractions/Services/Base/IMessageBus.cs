namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IProducer
{
    Task ProduceAsync<T>(
        T message,
        CancellationToken cancellationToken = default);
}
