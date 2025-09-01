using Kf.Service.Inventory.Domain.Models.Base;
using Kf.Service.Inventory.Domain.Services.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kf.Service.Inventory.Domain.Services;

public class InventoryMessageBus
    : KafkaMessageBusBase<InventoryMessageBus>,
        IInventoryMessageBus
{
    public InventoryMessageBus(
        IOptions<KafkaConfig> configKafka,
        ILogger<InventoryMessageBus> logger)
        : base(configKafka, logger)
    {
    }
}
