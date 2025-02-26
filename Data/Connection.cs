using Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection :DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Roles> Roles { get; set; } 

        public Connection(DbContextOptions<Connection> options) : base(options)
        {

        }
    }
}
