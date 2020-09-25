namespace PeruShop.Common.EventBus.Messaging
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PeruShop.Common.EventBus.RabbitMq;
    using RawRabbit;
    using RawRabbit.Enrichers.GlobalExecutionId;
    using RawRabbit.Enrichers.MessageContext;
    using RawRabbit.Enrichers.MessageContext.Context;
    using RawRabbit.Instantiation;
    using System;

    public static class Extensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RawRabbitConfigurationCustom();
            configuration.GetSection("RabbitMq").Bind(options);

            services.AddSingleton(context =>
            {
                var configuration = context.GetService<IConfiguration>();
                var options = configuration.GetSection("RabbitMq").Get<RawRabbitConfigurationCustom>();

                return options;
            });

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options,
                Plugins = p => p
                    .UseGlobalExecutionId()
                    .UseHttpContext()
                    .UseMessageContext(c => new MessageContext { GlobalRequestId = Guid.NewGuid() })
            });
            services.AddSingleton<IBusClient>(_ => client);

            services.AddScoped<IBusPublisher, BusPublisher>();

            return services;
        }

        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app) => new BusSubscriber(app);
    }
}