using Kf.Service.Inventory.Data.PosgreSql.Context;
using Kf.Service.Inventory.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Kf.Service.Inventory.Data.PosgreSql.Repositories;

public class InventoryRepository : InventoryRepository<DbContext>
{
    public InventoryRepository(
        InventoryDbContext dbContext,
        ISieveProcessor sieveProcessor)
        : base(dbContext, sieveProcessor)
    {
    }
}
