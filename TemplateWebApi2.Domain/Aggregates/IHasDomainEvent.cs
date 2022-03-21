using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Domain.Aggregates
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
