using TemplateWebApi2.Domain.Aggregates.Enums;
using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Domain.Aggregates
{
    public class Payment : Entity, IAggregateRoot, IHasDomainEvent
    {
        public virtual Order Order { get; set; }
        public double Amount { get; set; }
        public virtual PaymentStatus Status { get; set; }
        public virtual List<DomainEvent> DomainEvents { get; set; }


        public Payment(Order order)
        {
            //a payment cannot exist without a corresponding order
            Order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public void MakePayment(double amount)
        {
            Amount = amount;
        }
    }
}
