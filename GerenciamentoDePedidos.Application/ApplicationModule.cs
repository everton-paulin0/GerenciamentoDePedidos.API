using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Commands.InsertOrder;
using GerenciamentoDePedidos.Application.Services;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoDePedidos.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandler();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertOrderCommand>());

            return services;
        }

    }
}
