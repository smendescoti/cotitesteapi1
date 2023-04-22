using CentralDePedidos.Application.Interfaces.Publishers;
using CentralDePedidos.Application.Interfaces.Services;
using CentralDePedidos.Application.Services;
using CentralDePedidos.Domain.Interfaces.Repositories;
using CentralDePedidos.Domain.Interfaces.Services;
using CentralDePedidos.Domain.Services;
using CentralDePedidos.Infra.Data.Contexts;
using CentralDePedidos.Infra.Data.Repositories;
using CentralDePedidos.Infra.EventBus.Publishers;
using CentralDePedidos.Infra.EventBus.Settings;
using Microsoft.EntityFrameworkCore;

namespace CentralDePedidos.Services.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void Add(WebApplicationBuilder builder)
        {
            builder.Services.Configure<MessageBrokerSettings>
                (builder.Configuration.GetSection("MessageBrokerSettings"));

            var connectionString = builder.Configuration.GetConnectionString("ApiPedidos");
            builder.Services.AddDbContext<DataContext>
                (options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IPedidoAppService, PedidoAppService>();
            builder.Services.AddTransient<IPedidoDomainService, PedidoDomainService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IEventPublisher, EventPublisher>();
            builder.Services.AddTransient<DataContext>();
        }
    }
}
