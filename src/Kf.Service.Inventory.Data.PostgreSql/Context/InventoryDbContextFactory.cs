using Microsoft.Extensions.Configuration;

namespace Kf.Service.Inventory.Data.PosgreSql.Context;

public class InventoryDbContextFactory : PostgreSqlDbContextFactoryBase<InventoryDbContext>
{
    public InventoryDbContextFactory(
        IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override string ConnectionString => "ServiceDB";
}
