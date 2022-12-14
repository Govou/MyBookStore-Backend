using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;

namespace MyBookStore.Infrastructure.Context
{
    public class BookStoreContext : DbContext
    {

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
       : base(options)
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }


        //protected readonly IConfiguration Configuration;

        //public BookStoreContext(IConfiguration configuration)
        //{
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreContext).Assembly);
            base.OnModelCreating(modelBuilder);


            // modelBuilder.Entity<Publisher>()
            //.HasData(
            //    new Publisher("MichaelLuke"),
            //    new Publisher("BrianKay"),
            //    new Publisher("NeoLake"),
            //    new Publisher("HammerRio")
            //);


            // modelBuilder.Entity<Author>()
            //.HasData(
            //    new Author("Stephen John"),
            //    new Author("John Jake"),
            //    new Author("Paul Samuel"),
            //    new Author("Barry Mark")
            //);
        }



        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("Created").CurrentValue = DateTime.Now;
        //            continue;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("Created").IsModified = false;
        //            entry.Property("Updated").CurrentValue = DateTime.Now;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}