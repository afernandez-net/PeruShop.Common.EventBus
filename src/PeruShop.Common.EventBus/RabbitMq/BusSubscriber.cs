namespace PeruShop.Common.EventBus.RabbitMq
{
    using System;
    using System.Reflection;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using PeruShop.Common.EventBus.Messaging;
    using RawRabbit;
    using RawRabbit.Configuration.Exchange;    
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IBusClient _busClient;
        private readonly IServiceProvider _serviceProvider;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _busClient = _serviceProvider.GetService<IBusClient>();
        }

        public IBusSubscriber SubscribeEvent<TEvent>(string @nameexchange = null) where TEvent : IEvent, IRequest
        {
            _busClient.SubscribeAsync<TEvent>(async (@event) =>
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetService<IMediator>();

                    await handler.Send(@event);
                }
                catch (Exception ex)
                {
                    //Log.Error(ex, "Error al procesar el mensage");
                    throw ex;
                }

            }, ctx => ctx.UseSubscribeConfiguration(cfg => cfg
                .Consume(c => c.WithRoutingKey(typeof(TEvent).Name))
                .FromDeclaredQueue(q => q
                    .WithName(GetQueueName<TEvent>())
                    .WithDurability()
                    .WithAutoDelete(false))
                .OnDeclaredExchange(e => e
                  .WithName(@nameexchange)
                  .WithType(ExchangeType.Topic)
                  .WithArgument("key", typeof(TEvent).Name.ToLower()))
            ));
            return this;
        }

        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly()?.GetName().Name}/{typeof(T).Name}";
    }
}
