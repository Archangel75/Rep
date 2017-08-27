using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAppMvc1.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }

    public class CarDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            context.Cars.Add(new Car { Name = "Moseratti",Model = "A2 2015", Price = 100000});
            context.Cars.Add(new Car { Name = "Жигули", Model = "Веста", Price = 1000 });
            context.Cars.Add(new Car { Name = "Ford", Model = "Focus", Price = 5000 });

            base.Seed(context);
        }

    }
}