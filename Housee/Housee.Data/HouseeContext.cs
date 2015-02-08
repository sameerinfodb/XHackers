using Housee.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housee.Data
{
    internal class Context : DbContext
    {

        public Context()
            : base("name=HouseeContext")
        {
        }
        public DbSet<Chit> Chits { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Player> Players { get; set; }
       
    }
}
