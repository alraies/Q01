using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using Test5.Models;

namespace Test5.Data
{
    public class Test5DbContext : DbContext
    {



        public Test5DbContext(DbContextOptions<Test5DbContext> options)
       : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasSequence<int>("OrdersSequence")
                              .StartsAt(1000).IncrementsBy(1);
            modelBuilder.Entity<Order>()
               .Property(x => x.OrderNo)
               .HasDefaultValueSql("NEXT VALUE FOR OrdersSequence");

           

        }

    }
}
