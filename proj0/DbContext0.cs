using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proj0
{
    public class RPS_DbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        //protected override void OnConfigureing(DbContextOptionsBuilder options)
        //{
        //    if(!options.IsConfigured)
        //    options.UseSqlite("Data Source=broj0-db.db");
        //}
    }
}