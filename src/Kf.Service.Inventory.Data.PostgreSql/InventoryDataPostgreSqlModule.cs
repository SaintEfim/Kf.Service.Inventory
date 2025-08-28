using Autofac;
using Kf.Service.Inventory.Data.PosgreSql.Context;
using Kf.Service.Inventory.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kf.Service.Inventory.Data.PosgreSql;

public class InventoryDataPostgreSqlModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<InventoryDataModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IRepository<>))
            .AsImplementedInterfaces();

        builder.RegisterType<InventoryDbContextFactory>()
            .AsSelf()
            .SingleInstance();

        builder.Register(c => c.Resolve<InventoryDbContextFactory>()
                .CreateDbContext())
            .As<InventoryDbContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
