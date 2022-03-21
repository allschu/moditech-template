using Microsoft.EntityFrameworkCore;
using TemplateWebApi2.Domain.Aggregates;
using TemplateWebApi2.Infrastructure.Services;

namespace TemplateWebApi2.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private List<T> mockedDatabaseContext;

        private readonly IDomainEventService _domainEventService;

        public GenericRepository(IDomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
            mockedDatabaseContext = new List<T>();
        }

        public T Add(T type)
        {
            mockedDatabaseContext.Add(type);

            return type;
        }

        public T Get(Guid id)
        {
            return mockedDatabaseContext.SingleOrDefault(y => y.Id == id);
        }

        public bool Remove(T type)
        {
            return mockedDatabaseContext.Remove(type);
        }

        public void Update(T type)
        {
            throw new NotImplementedException();
        }
    }
}
