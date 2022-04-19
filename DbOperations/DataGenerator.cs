using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Week1_Patika.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CakeShopDbContext(serviceProvider.GetRequiredService<DbContextOptions<CakeShopDbContext>>()))
            {
                if (context.Cakes.Any())
                {
                    return;
                }


                context.Cakes.AddRange(new Cake()
                {
                    Id = 1,
                    CakeName= "Blueberry Dream",
                    CategoryId =1, //Fruity
                    Stock = 50,
                    ExpirationDate = new DateTime(2022,2,25)

                },

                new Cake()
                {
                    Id = 2,
                    CakeName = "Chocolate Garden",
                    CategoryId = 2, //Chocolate
                    Stock = 25,
                    ExpirationDate = new DateTime(2022, 3, 15)
                },

                new Cake()
                {
                    Id = 2,
                    CakeName = "Cake the little",
                    CategoryId = 3, //Cup Cake
                    Stock = 150,
                    ExpirationDate = new DateTime(2022, 6, 29)
                });

                context.SaveChanges();
            }
        }
    }

}
