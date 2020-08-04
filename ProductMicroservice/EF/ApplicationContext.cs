using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(@"..\ProductMicroservice"))
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("connectionString"));
        }
    }
}
