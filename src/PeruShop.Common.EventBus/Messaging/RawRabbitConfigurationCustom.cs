namespace PeruShop.Common.EventBus.Messaging
{
    using RawRabbit.Configuration;

    public class RawRabbitConfigurationCustom : RawRabbitConfiguration
    {
        public string NameExchange { get; set; }
    }
}