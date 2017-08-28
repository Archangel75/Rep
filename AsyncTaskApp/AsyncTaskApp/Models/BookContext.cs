using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsyncTaskApp.Models
{
    public class BookContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.Add(new Book { name = "Moseratti", author = "A2 2015", price = 100000 });
            context.Books.Add(new Book { name = "Жигули", author = "Веста", price = 1000 });
            context.Books.Add(new Book { name = "Ford", author = "Focus", price = 5000 });

            base.Seed(context);
        }

    }
}