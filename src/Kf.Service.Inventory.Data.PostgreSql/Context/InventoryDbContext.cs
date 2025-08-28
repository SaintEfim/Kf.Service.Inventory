using Kf.Service.Inventory.Data.Models;
using Kf.Service.Inventory.Data.PosgreSql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kf.Service.Inventory.Data.PosgreSql.Context;

public sealed class InventoryDbContext : DbContext
{
    public InventoryDbContext(
        DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<InventoryEntity> Inventories { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
