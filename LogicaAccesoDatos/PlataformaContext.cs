using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;
using LogicaNegocio.Parametros;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class PlataformaContext: DbContext
    {
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<EstadoConservacion> EstadosConservacion { get; set; }

        public DbSet<Parametro> Parametros { get; set; }

        public PlataformaContext(DbContextOptions<PlataformaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().OwnsOne(pa => pa.nombrePais).HasIndex(nom => nom.nombre).IsUnique();
            modelBuilder.Entity<Pais>().HasIndex(nom => nom.codigoIsoAlpha).IsUnique();
            // modelBuilder.Entity<Ecosistema>().OwnsOne(ec => ec.nombreEcosistema).HasIndex(no => no.nombre).IsUnique();
            modelBuilder.Entity<Ecosistema>().HasMany(ec => ec.amenazas).WithOne();
            modelBuilder.Entity<Ecosistema>().HasOne(ec => ec.estado);
            modelBuilder.Entity<Ecosistema>().HasMany(ec => ec.especies).WithOne();
            modelBuilder.Entity<Especie>().HasMany(ec => ec.AmenazasEspecie).WithOne();
            modelBuilder.Entity<Especie>().HasMany(ec => ec.ecosistemasHabitados).WithOne();
                                              


            base.OnModelCreating(modelBuilder);
        }
    }
}
