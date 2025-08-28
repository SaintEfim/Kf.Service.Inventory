using Kf.Service.Inventory.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kf.Service.Inventory.Data.PosgreSql.Configurations;

internal sealed class InventoryEntityConfiguration : IEntityTypeConfiguration<InventoryEntity>
{
    public void Configure(
        EntityTypeBuilder<InventoryEntity> builder)
    {
        builder.ToTable("Inventories");
    }
}
