using Autofac;
using Kf.Service.Inventory.Data.Profile;
using Sieve.Services;

namespace Kf.Service.Inventory.Data;

public class InventoryDataModule : Module
{
    protected override void Load(
        ContainerBuilder builder)
    {
        builder.RegisterType<SieveProcessor>()
            .As<ISieveProcessor>();

        builder.RegisterType<ApplicationSieveProcessor>()
            .As<ISieveProcessor>()
            .SingleInstance();
    }
}
