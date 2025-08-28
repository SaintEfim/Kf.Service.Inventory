using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Kf.Service.Inventory.Data.Repositories;

public class InventoryRepository<TDbContext>
    : RepositoryBase<TDbContext, InventoryEntity>,
        IInventoryRepository
    where TDbContext : DbContext
{
    protected InventoryRepository(
        TDbContext dbContext,
        ISieveProcessor sieveProcessor)
        : base(dbContext, sieveProcessor)
    {
    }
}
