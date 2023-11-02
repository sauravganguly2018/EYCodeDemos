using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFDemoApp.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        // configure the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IN3487131W1\\SQLEXPRESS01;Initial Catalog=ProductsCatalogEY2023;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information);

            optionsBuilder.UseLazyLoadingProxies(true);
        }

        // configure the tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
