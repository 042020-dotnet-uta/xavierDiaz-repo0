using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace rocPapSci_obj
{
    public class RPS_DbContext : DbContext 
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            if(!options.IsConfigured){
                options.UseSqlite("Data Source=rpsGame.db");
            }
        }
    }
}