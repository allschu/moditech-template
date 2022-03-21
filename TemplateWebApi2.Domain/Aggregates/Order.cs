using TemplateWebApi2.Domain.Aggregates.Enums;
using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Domain.Aggregates
{
    public class Order : Entity, IAggregateRoot , IHasDomainEvent
    {
        public virtual DateTime OrderDate { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual double TotalAmount
        {
            get
            {
                return Products.Sum(x => x.Price);
            }
        }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual List<DomainEvent> DomainEvents { get; set; }

        public Order(List<Product> products)
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.New;

            if (!products.Any())
            {
                //an order cannot exists without products
                throw new ArgumentNullException(nameof(products));
            }

            Products = products;
            Payments = new List<Payment>();
            DomainEvents = new List<DomainEvent>();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (product.Status == ProductStatus.Terminated)
            {
                //product cannot be ordered anymore since its no longer being sold
                return;
            }

            Products.Add(product);
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }

        public void SubmitOrder()
        {
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Accepted;

            //Domain event submit
        }

        public void CancelOrder()
        {
            if (Status == OrderStatus.Accepted)
            {
                //Domain event cancel order!
            }
            else
            {
                //Order cannot be cancelled anymore
            }
        }
    }
}
