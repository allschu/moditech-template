using TemplateWebApi2.Domain.Aggregates.Enums;
using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Domain.Aggregates
{
    public class Product : Entity, IAggregateRoot, IHasDomainEvent
    {
        public virtual string Name { get; }
        public virtual ProductStatus Status { get; set; }
        public virtual double Price { get; }
        public virtual double Vat { get; set; }
        public virtual List<DomainEvent> DomainEvents { get; set; }


        public Product(string name, double price, double vat)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Vat = vat;
        }
    }
}
