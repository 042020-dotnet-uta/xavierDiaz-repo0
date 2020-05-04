using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectZero
{
    public class Pzero_DbContextClass : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=Pzero.db");
            }
        }
    }
}
