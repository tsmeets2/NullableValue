using Microsoft.EntityFrameworkCore;
using NullableValue.Models;
using Microsoft.Extensions.Configuration;

namespace NullableValue.Data
{
    public partial class TestContext : DbContext
    {
        public string ConnectionString { get; private set; } = "";

        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                ConnectionString = configuration.GetConnectionString("TestConString");

                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public virtual DbSet<MenuPage> MenuPages { get; set; }

        public virtual DbSet<MenuGroup> MenuGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuPage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

            });

            modelBuilder.Entity<MenuGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
