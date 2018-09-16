using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace client.Models
{
    class BaseContext : DbContext
    {
        public BaseContext() : base("SQLite")
        {

        }

        public DbSet<Options> Options { get; set; }
    }
}
