using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteSWFast.IO.Domain.Products;
using TesteSWFast.IO.Infra.Data.Extensions;
using TesteSWFast.IO.Infra.Data.Mappings;

namespace TesteSWFast.IO.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CategoryMapping());
            modelBuilder.AddConfiguration(new ProductMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
