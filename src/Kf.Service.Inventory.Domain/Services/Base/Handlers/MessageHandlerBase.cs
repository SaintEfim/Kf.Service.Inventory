using System.Text;
using Kf.Service.Inventory.Domain.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kf.Service.Inventory.Domain.Services.Base.Handlers;

public abstract class MessageHandlerBase<TMessage> : IMessageHandler<TMessage>
    where TMessage : class
{
    protected virtual TMessage? Deserialize(
        byte[] data)
    {
        using var stream = new MemoryStream(data, false);
        using var reader = new StreamReader(stream, Encoding.UTF8);

        return (TMessage?) JsonSerializer.Create(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            })
            .Deserialize(reader, typeof(TMessage));
    }

    /// <summary>
    /// Handles received messages.
    /// </summary>
    /// <param name="data">The message content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The status of message handling. See <see cref="MessageHandlingResult"/> for details.</returns>
    public virtual Task<MessageHandlingResult> Handle(
        byte[] data,
        CancellationToken cancellationToken = default)
    {
        var message = Deserialize(data);

        if (message == null)
        {
            return Task.FromResult(MessageHandlingResult.FailedSentToDeadLetterQueue);
        }

        return Handle(message, cancellationToken);
    }

    protected abstract Task<MessageHandlingResult> Handle(
        TMessage message,
        CancellationToken cancellationToken = default);
}
