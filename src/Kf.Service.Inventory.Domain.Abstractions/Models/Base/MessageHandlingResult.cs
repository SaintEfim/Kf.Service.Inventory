namespace Kf.Service.Inventory.Domain.Models.Base;

public enum MessageHandlingResult
{
    Succeeded,
    FailedRequeue,
    FailedSentToDeadLetterQueue,
    Dropped
}
