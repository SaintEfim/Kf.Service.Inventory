using Autofac;
using Kf.Service.Inventory.Data.PosgreSql;
using Kf.Service.Inventory.Domain.Services;
using Kf.Service.Inventory.Domain.Services.Base;
using Kf.Service.Inventory.Domain.Services.Base.Kafka;

namespace Kf.Service.Inventory.Domain;

public class InventoryDomainModule : Module
{
    /// <summary>
    /// Возвращает ключ для обработчика на основе IMessageHandler&lt;TMessage&gt;.
    /// Бросает InvalidOperationException если тип не реализует IMessageHandler&lt;T&gt;.
    /// </summary>
    private static string GetMessageHandlerKey(
        Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        var handlerInterface = type.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMessageHandler<>));

        if (handlerInterface == null)
            throw new InvalidOperationException($"Type {type.FullName} does not implement IMessageHandler<T>.");

        var messageType = handlerInterface.GetGenericArguments()
            .First();

        return messageType.FullName ?? messageType.Name;
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
    }
}
