﻿using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.DataContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ReturnedProduct> ReturnedProducts { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(user => !user.IsDeleted);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Expense>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<Order>()
                .HasQueryFilter(c => !c.IsDeleted);

            modelBuilder.Entity<ReturnedProduct>()
                .HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
