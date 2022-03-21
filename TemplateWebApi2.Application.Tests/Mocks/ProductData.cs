using System.Collections.Generic;
using TemplateWebApi2.Domain.Aggregates;

namespace TemplateWebApi2.Application.Tests.Mocks
{
    public static class ProductData
    {
        public static List<Product> GenerateProducts()
        {
            return new List<Product>()
            {
                new Product("Product 1", 10, 0.2),
                new Product("Product 2", 25, 0.25),
                new Product("Product 3", 199, 0.11),
                new Product("Product 4", 2.9, 0.18),
                new Product("Product 5", 145.95, 0.21)
            };
        }

        public static Product GenerateProduct()
        {
            return new Product("Product Single", 32.15, 0.13);
        }
    }
}
