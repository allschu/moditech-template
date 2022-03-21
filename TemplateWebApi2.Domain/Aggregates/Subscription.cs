using TemplateWebApi2.Domain.Aggregates.Enums;

namespace TemplateWebApi2.Domain.Aggregates
{
    public class Subscription : Entity, IAggregateRoot
    {
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual SubscriptionStatus Status { get; set; }
        public virtual Product ProductSubscription { get; set; }
        public virtual Customer Customer { get; set; }

        public Subscription(Customer customer, Product product)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            ProductSubscription = product ?? throw new ArgumentNullException(nameof(product));

            Id = Guid.NewGuid();

            //default a subscription is 30 day trial
            EndDate = DateTime.UtcNow.AddDays(30);
            Status = SubscriptionStatus.Trial;
        }

        /// <summary>
        /// Start Subscription by setting the startdate
        /// </summary>
        public Subscription StartSubscription()
        {
            //**** questions ******
            //can a subscription start without a payment?
            //must there be a confirmation mail send to the customer?

            StartDate = DateTime.UtcNow;

            return this;
        }

        /// <summary>
        /// Extend subscription by amount of years
        /// </summary>
        /// <param name="years"></param>
        public Subscription ExtendSubscription(int years)
        {
            EndDate.AddYears(years);
            Status = SubscriptionStatus.Active;

            //Domain event extend so that means a new order

            return this;
        }

        /// <summary>
        /// Stop the subscription
        /// </summary>
        public Subscription StopSubscription()
        {
            Status = SubscriptionStatus.Expired;
            EndDate = DateTime.UtcNow;

            return this;
        }
    }
}
