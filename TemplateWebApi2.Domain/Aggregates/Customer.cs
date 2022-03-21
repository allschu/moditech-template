using TemplateWebApi2.Domain.Aggregates.ValueTypes;

namespace TemplateWebApi2.Domain.Aggregates
{
    public class Customer : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public virtual IReadOnlyCollection<Order> Orders { get; }
        public virtual IReadOnlyCollection<Payment> Payments { get; }

        public Customer(string name, Address billingAddress, Address shippingAddress)
        {
            Name = name;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
        }
    }
}
