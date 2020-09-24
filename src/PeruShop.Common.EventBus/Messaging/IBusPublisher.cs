namespace PeruShop.Common.EventBus.Messaging
{
    using System.Threading.Tasks;
    public interface IBusPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}