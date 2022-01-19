using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ASP_NET_FINAL_TEST.Models
{
    public partial class VillageDatabaseContext : DbContext
    {
        public VillageDatabaseContext()
            : base("name=VillageDatabaseContext")
        {
        }

        public DbSet<Citizen> Citizens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
