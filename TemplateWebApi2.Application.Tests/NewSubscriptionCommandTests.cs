using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System;
using System.Reflection;
using System.Threading.Tasks;
using TemplateWebApi2.Application.Commands;
using TemplateWebApi2.Application.Dependencies;
using TemplateWebApi2.Application.Tests.Mocks;
using TemplateWebApi2.Domain.Aggregates;
using TemplateWebApi2.Infrastructure;
using TemplateWebApi2.Infrastructure.Services;
using Xunit;

namespace TemplateWebApi2.Application.Tests
{
    public class NewSubscriptionCommandTests
    {
        private readonly ServiceProvider serviceProvider;

        public NewSubscriptionCommandTests()
        {
            //Initialize
            var mockedCustomerRepository = new Mock<IGenericRepository<Customer>>();
            var mockedProductRepostiroy = new Mock<IGenericRepository<Product>>();

            mockedCustomerRepository.Setup(setup => setup.Get(It.IsAny<Guid>())).Returns(CustomerData.GenerateCustomer());
            mockedProductRepostiroy.Setup(setup => setup.Get(It.IsAny<Guid>())).Returns(ProductData.GenerateProduct());

            var services = new ServiceCollection();
            services.AddScoped<IMediator, Mediator>();
            services.AddLogging();
            services.AddApplicationsDependencies();
            services.TryAdd(ServiceDescriptor.Transient(typeof(IGenericRepository<>), typeof(GenericRepository<>)));
            services.AddSingleton(mockedCustomerRepository.Object);
            services.AddSingleton(mockedProductRepostiroy.Object);
            services.AddTransient<IDomainEventService, DomainEventService>();

            serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task NewSubscriptionCommandTest()
        {
            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var result = await mediator.Send(new NewSubscriptionCommand(Guid.NewGuid(), Guid.NewGuid()));

            result.Should().BeTrue();
        }
    }
}
