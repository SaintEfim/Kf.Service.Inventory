namespace Kf.Service.Inventory.Domain.Models.Base.Kafka;

public enum MessageHandlingResult
{
    Succeeded,
    FailedRequeue,
    FailedSentToDeadLetterQueue,
    Dropped
}
