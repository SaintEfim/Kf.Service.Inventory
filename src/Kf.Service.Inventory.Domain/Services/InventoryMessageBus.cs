using Autofac.Features.Indexed;
using Kf.Service.Inventory.Domain.Models.Base.Kafka;
using Kf.Service.Inventory.Domain.Services.Base.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryMessageBus
    : KafkaMessageBusBase<IInventoryMessageHandler>,
        IInventoryMessageBus
{
    public InventoryMessageBus(
        IOptions<KafkaConfig> configKafka,
        ILogger<IInventoryMessageHandler> logger,
        IIndex<string, IInventoryMessageHandler> handlers)
        : base(configKafka, logger, handlers)
    {
    }
}
