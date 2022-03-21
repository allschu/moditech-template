using MediatR;
using Microsoft.Extensions.Logging;
using TemplateWebApi2.Application.Commands;
using TemplateWebApi2.Domain.Aggregates;
using TemplateWebApi2.Infrastructure;

namespace TemplateWebApi2.Application.CommandHandlers
{
    public class NewSubscriptionCommandHandler : IRequestHandler<NewSubscriptionCommand, bool>
    {
        private readonly ILogger<NewSubscriptionCommandHandler> _logger;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Subscription> _subscriptionRepository;

        public NewSubscriptionCommandHandler(ILogger<NewSubscriptionCommandHandler> logger,
            IGenericRepository<Customer> customerRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<Subscription> subscriptionRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> Handle(NewSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"");

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning($"{nameof(NewSubscriptionCommandHandler)} received a cancelled command of type {typeof(NewSubscriptionCommand)}");
                    return false;
                }

                var customer = _customerRepository.Get(request.CustomerId);
                var product = _productRepository.Get(request.ProductId);

                _logger.LogInformation($"new subscription for customer {customer} of product {product} has been initiated ");

                var newSubscription = new Subscription(customer, product);
                var subscription = newSubscription.StartSubscription();

                _subscriptionRepository.Add(subscription);

                return subscription != null;
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to start subscription");
                _logger.LogError(ex.Message, ex);

                return false;
            }
        }
    }
}
