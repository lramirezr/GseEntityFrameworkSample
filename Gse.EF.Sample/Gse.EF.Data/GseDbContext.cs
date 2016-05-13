using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.EF.Data
{
    public class GseDbContext : DbContext
    {
        public GseDbContext()
           : base("name=GseContext")
        {
            //Disable initializer
            Database.SetInitializer<GseDbContext>(null);
        }
        public static GseDbContext Create()
        {
            return new GseDbContext();
        }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Empresa>().ToTable("COM_EMPRESAS");

            modelBuilder.Entity<Empresa>().HasKey<decimal>(e => e.Id);

            modelBuilder.Entity<Empresa>()
                .Property(p => p.Id)
                .HasColumnName("OID");

            modelBuilder.Entity<Empresa>()
                .Property(p => p.Cif)
                .HasColumnName("ATR_CODIGO");

            // base.OnModelCreating(modelBuilder);
        }
    }
}
