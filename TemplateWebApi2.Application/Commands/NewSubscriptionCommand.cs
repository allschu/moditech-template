using MediatR;

namespace TemplateWebApi2.Application.Commands
{
    public class NewSubscriptionCommand : IRequest<bool>
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public NewSubscriptionCommand(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
