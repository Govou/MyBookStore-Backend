using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBookStore.Domain.Entities;
using MyBookStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Infrastructure.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>());

            }

        }

        public static void SeedData(this BookStoreContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if (!context.Author.Any())
            {
                context.Author.AddRange(new Author("Stephen John"),
                                        new Author("John Jake"),
                                        new Author("Paul Samuel"),
                                        new Author("Barry Mark"));
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                Console.WriteLine("Author table already has data... Not seeding!!!");
            }

            if (!context.Publisher.Any())
            {
                context.Publisher.AddRange(new Publisher("MichaelLuke"),
                                           new Publisher("BrianKay"),
                                           new Publisher("NeoLake"),
                                           new Publisher("HammerRio"));

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Publisher table already has data... Not seeding!!!");
            }
        }
    }
}
