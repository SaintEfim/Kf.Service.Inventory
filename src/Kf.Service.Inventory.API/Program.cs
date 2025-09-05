using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kf.Service.Inventory.Domain;
using Kf.Service.Inventory.Domain.Models.Base.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddOpenApiDocument();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly, Assembly.GetExecutingAssembly());
builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection("KafkaConfig"));

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<InventoryDomainModule>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseRouting();
app.MapControllers();

await app.RunAsync();
