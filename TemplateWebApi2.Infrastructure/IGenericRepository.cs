using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWebApi2.Domain.Aggregates;

namespace TemplateWebApi2.Infrastructure
{
    public interface IGenericRepository <T> where T : Entity
    {
        T Add(T type);
        void Update(T type);
        T Get(Guid id);
    }
}
