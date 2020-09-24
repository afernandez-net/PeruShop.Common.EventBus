namespace PeruShop.Services.Customers.Handlers.Customers
{
    using MediatR;
    using PeruShop.Common.EventBus.Messaging;
    using PeruShop.Services.Customers.Messages.Commands;
    using PeruShop.Services.Customers.Messages.Events;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCustomerHandler : AsyncRequestHandler<CreateCustomer>
    {
        private readonly IBusPublisher _busPublisher;

        public CreateCustomerHandler(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        protected override async Task Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            //add repository
       
            await _busPublisher.PublishAsync(new CustomerCreated(request.Id, "request.Email", request.FirstName, request.LastName, request.Address, request.Country));
        }
    }
}