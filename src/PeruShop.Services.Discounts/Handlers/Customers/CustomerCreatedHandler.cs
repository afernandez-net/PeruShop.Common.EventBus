namespace PeruShop.Services.Discounts.Handlers.Customers
{
    using MediatR;
    using PeruShop.Services.Discounts.Messages.Events;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomerCreatedHandler : AsyncRequestHandler<CustomerCreated>
    {
        protected override Task Handle(CustomerCreated request, CancellationToken cancellationToken)
        {
            //add repository
            return Task.Run(() =>
            {
            });
        }
    }
}