using Autofac;
using Kf.Service.Inventory.Data.PosgreSql;
using Kf.Service.Inventory.Domain.Services.Base;

namespace Kf.Service.Inventory.Domain;

public class InventoryDomainModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterModule<InventoryDataPostgreSqlModule>();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataProvider<>))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AsClosedTypesOf(typeof(IDataManager<>))
            .AsImplementedInterfaces();
    }
}
