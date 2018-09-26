using System.IO;
using DockerSample.Domain.Models;
using DockerSample.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DockerSample.Infra.Data.Context
{
    public class DockerSampleContext : DbContext
    {
        public DockerSampleContext(DbContextOptions<DockerSampleContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DockerSampleConnectionString"));
        }
    }
}
