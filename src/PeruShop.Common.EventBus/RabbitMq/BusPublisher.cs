namespace PeruShop.Common.EventBus.RabbitMq
{
    using System.Threading.Tasks;
    using PeruShop.Common.EventBus.Messaging;
    using RawRabbit;
    using RawRabbit.Configuration.Exchange;
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;
        private readonly RawRabbitConfigurationCustom _rawRabbitConfigurationCustom;

        public BusPublisher(IBusClient busClient, RawRabbitConfigurationCustom rawRabbitConfigurationCustom)
        {
            _busClient = busClient;
            _rawRabbitConfigurationCustom = rawRabbitConfigurationCustom;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            await _busClient.PublishAsync(@event, ctx => ctx
                .UsePublishConfiguration(cfg => cfg
                    .OnDeclaredExchange(e => e
                        .WithName(_rawRabbitConfigurationCustom.NameExchange)
                        .WithType(ExchangeType.Topic))
                    .WithRoutingKey(typeof(TEvent).Name)));
        }
    }
}
