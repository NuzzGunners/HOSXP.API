using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOSXP.API.Models
{
    public class HOSXPContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=P@ssw0rd;Host=localhost;Port=5432;Database=NUZZDB;Pooling=true;");
        }
        public virtual DbSet<V_NURSE> V_NURSE { get; set; }
        public virtual DbSet<V_WARD> V_WARD { get; set; }
        public virtual DbSet<V_DOCTOR> V_DOCTOR { get; set; }
        public virtual DbSet<V_ACCOUNT> V_ACCOUNT { get; set; }
        public virtual DbSet<V_IPD> V_IPD { get; set; }
    }
}
