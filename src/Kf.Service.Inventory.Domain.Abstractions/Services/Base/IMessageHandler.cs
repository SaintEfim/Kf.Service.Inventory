using Kf.Service.Inventory.Domain.Models.Base.Kafka;

namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IMessageHandler
{
    Task<MessageHandlingResult> Handle(
        byte[] data,
        CancellationToken cancellationToken = default);
}

public interface IMessageHandler<in TMessage> : IMessageHandler
    where TMessage : class;
