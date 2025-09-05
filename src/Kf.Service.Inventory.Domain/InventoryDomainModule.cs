using Autofac;
using Kf.Service.Inventory.Data.PosgreSql;
using Kf.Service.Inventory.Domain.Services;
using Kf.Service.Inventory.Domain.Services.Base;
using Kf.Service.Inventory.Domain.Services.Base.Kafka;
using Kf.Service.Inventory.Domain.Services.Base.Kafka.Handlers;

namespace Kf.Service.Inventory.Domain;

public class InventoryDomainModule : Module
{
    private static string GetMessageHandlerKey(
        Type type)
    {
        return type.GetInterfaces()
            .Where(x => x.IsClosedTypeOf(typeof(IMessageHandler<>)))
            .Select(x => x.GenericTypeArguments[0])
            .First()
            .Name;
    }

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

        builder.RegisterType<InventoryMessageBus>()
            .AsImplementedInterfaces()
            .SingleInstance();

        builder.RegisterAssemblyTypes(ThisAssembly)
            .AssignableTo<IInventoryMessageHandler>()
            .Keyed<IInventoryMessageHandler>(t => GetMessageHandlerKey(t));

        builder.RegisterType<MessageBusHandleManager>()
            .AsImplementedInterfaces()
            .SingleInstance();

        builder.RegisterType<KafkaTopicCreator>()
            .As<ITopicCreator>()
            .SingleInstance();

        builder.RegisterType<MessageBusInitializationService>()
            .AsImplementedInterfaces()
            .SingleInstance();
    }
}
