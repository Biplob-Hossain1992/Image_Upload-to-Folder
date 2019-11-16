using CRUDOperation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.DatabaseContext
{
    public class CRUDOperationDbContext : IdentityDbContext<IdentityUser> //use for authentication
    {
        public long CurrentUserId { get; set; }

        public CRUDOperationDbContext(DbContextOptions options) : base(options)
        {

        }

        public CRUDOperationDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Variant> Variants { get; set; }
        public DbSet<Size> Sizes { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public object Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(true)
                .UseSqlServer("Server=(local);Database=CRUDOperation_Authentication; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//used for authentication
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => p.IsActive); //use for isActive filtering

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Stock)
            //    .WithOne(p => p.Product).IsRequired(false);


            //modelBuilder.Entity<Stock>()
            //    .HasOne(p => p.Product)
            //    .WithOne(p => p.Stock).IsRequired(false);


            //modelBuilder.Entity<Category>(category =>
            //{
            //    category.HasMany(c => c.Childs)
            //    .WithOne(c => c.Parent)
            //    .HasForeignKey(c => c.ParentId);

            //});
            /*Product order relationship---------Start-------------*/
            modelBuilder.Entity<ProductOrder>().HasKey(c => new { c.ProductId, c.OrderId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Order)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.OrderId);

            /*Product order relationship---------End-------------*/
        }
    }
}
