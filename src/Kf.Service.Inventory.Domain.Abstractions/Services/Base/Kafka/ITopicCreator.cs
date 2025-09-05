namespace Kf.Service.Inventory.Domain.Services.Base.Kafka;

public interface ITopicCreator
{
    Task CreateTopic(
        CancellationToken cancellationToken = default);
}
