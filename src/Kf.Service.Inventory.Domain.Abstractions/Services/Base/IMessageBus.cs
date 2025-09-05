namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IMessageBus
{
    Task SendMessage<T>(
        T message,
        CancellationToken cancellationToken = default);

    Task StartHandling(
        CancellationToken stoppingToken = default);
}
