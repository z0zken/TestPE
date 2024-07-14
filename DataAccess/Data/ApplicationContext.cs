using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ApplicationContext"));
            }
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Supplier> Supplier { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<Account> Account { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.CreateYear)
                .HasDefaultValue(DateTime.Now.Year);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Address)
                .WithMany()
                .HasForeignKey(s => s.AddressId);

            modelBuilder.Entity<Account>()
                .HasData(
                new Account
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Role = "Manager"
                },
                new Account
                {
                    Id = 2,
                    Username = "staff",
                    Password = "staff",
                    Role = "Staff"
                },
                new Account
                {
                    Id = 3,
                    Username = "user",
                    Password = "user",
                    Role = "User"
                }
                );

        }
    }
}
