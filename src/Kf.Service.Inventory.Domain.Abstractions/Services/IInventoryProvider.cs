using Kf.Service.Inventory.Domain.Models;
using Kf.Service.Inventory.Domain.Services.Base;

namespace Kf.Service.Inventory.Domain.Services;

public interface IInventoryProvider : IDataProvider<InventoryModel>;
