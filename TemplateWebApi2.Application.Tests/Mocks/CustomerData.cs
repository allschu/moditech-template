using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWebApi2.Domain.Aggregates;
using TemplateWebApi2.Domain.Aggregates.ValueTypes;

namespace TemplateWebApi2.Application.Tests.Mocks
{
    public static class CustomerData
    {
        public static List<Customer> GenerateCustomers()
        {
            return new List<Customer>()
            {
                new Customer("Customer 1",
                    new Address("Herenweg", "Hoogwoud", string.Empty, "Netherlands", "1718"),
                    new Address("Koningspade", "Hoogwoud", string.Empty, "Netherlands", "1237")
                    ),
                new Customer("Customer 2",
                    new Address("Rietlaan", "Bergen op Zoom", string.Empty, "Netherlands", "4774"),
                    new Address("Raadweg", "Landsbeek", string.Empty, "Netherlands", "1326")
                    ),
                new Customer("Customer 3",
                    new Address("Magrietje", "Zwolle", string.Empty, "Netherlands", "2689"),
                    new Address("Reiger", "Vleuten", string.Empty, "Netherlands", "1111")
                    ),
                new Customer("Customer 4",
                    new Address("Zandweg", "Dronten", string.Empty, "Netherlands", "5894"),
                    new Address("Velsenweg", "Ermelo", string.Empty, "Netherlands", "3569")
                    )

            };
        }

        public static Customer GenerateCustomer()
        {
            return new Customer("SingleCustomer 4",
                    new Address("Renaultlaan", "Zeewolde", string.Empty, "Netherlands", "5894"),
                    new Address("Raadhuis", "Harderwijk", string.Empty, "Netherlands", "3569")
                    );

        }
    }
}
