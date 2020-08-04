using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(@"..\OrderMicroservice"))
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("connectionString"));
        }
    }
}
