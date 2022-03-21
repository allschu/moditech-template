using TemplateWebApi2.Domain.Aggregates;

namespace TemplateWebApi2.Domain.Events
{
    public class NewSubscriptionCreatedEvent : DomainEvent
    {
        public Subscription Subscription{get;set;}
        public NewSubscriptionCreatedEvent(Subscription subscription)
        {
            Subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));
        }
    }
}
