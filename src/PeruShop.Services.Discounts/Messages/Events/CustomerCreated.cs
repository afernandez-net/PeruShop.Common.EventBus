namespace PeruShop.Services.Discounts.Messages.Events
{
    using MediatR;
    using Newtonsoft.Json;
    using PeruShop.Common.EventBus.Messaging;
    using System;

    public class CustomerCreated : IEvent, IRequest
    {
        public Guid Id { get; }
        public string Email { get; }

        [JsonConstructor]
        public CustomerCreated(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}