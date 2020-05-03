using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pZero
{
    public class Pzero_DbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=Pzero.db");
            }
        }
    }
}
