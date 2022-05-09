using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Api.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (ProductDbContext context = new ProductDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Hırka",
                        CategoryId = 1,
                        Stock = 123,
                        CreatedDate = new DateTime(2019, 06, 12)
                    },
                    new Product
                    {
                        ProductName = "Gömlek",
                        CategoryId = 2,
                        Stock = 123,
                        CreatedDate = new DateTime(2019, 06, 12)

                    },
                    new Product
                    {
                         ProductName = "Ayakkabı",
                         CategoryId = 3,
                         Stock = 123,
                         CreatedDate = new DateTime(2019, 06, 12)

                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
