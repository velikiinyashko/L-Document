using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace server.Models
{
    class BaseContext : DbContext
    {
        public DbSet<Options> Options { get; set; }
        public DbSet<Logging> Loggings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        }
    }
}
