using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TemplateWebApi2.Domain.Events;

namespace TemplateWebApi2.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;

        public DomainEventService(ILogger<DomainEventService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Publish(DomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation($"publish domain event ----- {domainEvent.GetType()}");

                //Implement service bus

                domainEvent.IsPublished = true;
            }
            catch (Exception ex)
            {
                //implement logic with retry mechanism
                _logger.LogError(ex.Message, ex);
            }

        }
    }
}
