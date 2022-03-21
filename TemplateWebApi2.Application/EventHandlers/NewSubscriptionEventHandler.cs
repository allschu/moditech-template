using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Application.EventHandlers
{
    public class NewSubscriptionEventHandler : INotificationHandler<DomainEventNotification<NewSubscriptionCreatedEvent>>
    {
        private readonly ILogger<NewSubscriptionEventHandler> _logger;
        public NewSubscriptionEventHandler(ILogger<NewSubscriptionEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(DomainEventNotification<NewSubscriptionCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation($"Domain Event: {domainEvent.GetType().Name}");

            return Task.CompletedTask;
        }
    }
}
