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

        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            /* 
             * Entidad ~ COM_ENTIDADES 
             */
            modelBuilder.Entity<Entidad>().ToTable("COM_ENTIDADES");
            // primaryKey
            modelBuilder.Entity<Entidad>().HasKey<decimal>(e => e.Id);
            // map fields names
            modelBuilder.Entity<Entidad>()
                .Property(p => p.Id)
                .HasColumnName("OID");

            modelBuilder.Entity<Entidad>()
                .Property(p => p.Nombre)
                .HasColumnName("ATR_NOMBRE");

            modelBuilder.Entity<Entidad>()
                .Property(p => p.RazonSocial)
                .HasColumnName("ATR_RAZONSOCIAL");
            //// relationship [ANOTHER WAY TO KNOW... IT... RELATIONSHIPS... ;-O]
            //modelBuilder.Entity<Entidad>()
            //    .HasMany<Empresa>(e => e.Empresas)
            //    .WithRequired(e => e.Entidad);

            /* 
             * Empresa ~ COM_EMPRESAS 
             */
            modelBuilder.Entity<Empresa>().ToTable("COM_EMPRESAS");
            // primaryKey
            modelBuilder.Entity<Empresa>().HasKey<decimal>(e => e.Id);
            // map fields names
            modelBuilder.Entity<Empresa>()
                .Property(p => p.Id)
                .HasColumnName("OID");

            modelBuilder.Entity<Empresa>()
                .Property(p => p.Cif)
                .HasColumnName("ATR_CODIGO");

            modelBuilder.Entity<Empresa>()
                .Property(p => p.Tipo)
                .HasColumnName("ATR_TIPOEMPRESA");

            modelBuilder.Entity<Empresa>()
                            .Property(p => p.EntidadId)
                            .HasColumnName("IOR_ENTIDAD");
            // relationship
            modelBuilder.Entity<Empresa>()
                .HasOptional<Entidad>(e => e.Entidad)
                .WithMany(e => e.Empresas);
                // .HasForeignKey(e=>e.EntidadId);
        }
    }
}
