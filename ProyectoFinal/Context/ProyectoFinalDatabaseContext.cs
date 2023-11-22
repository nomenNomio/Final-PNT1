
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using System.Collections.Generic;
using System.Collections;

namespace ProyectoFinal.Context
{
    public class ProyectoFinalDatabaseContext : DbContext
    {

        public ProyectoFinalDatabaseContext(DbContextOptions<ProyectoFinalDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cuenta>()
                .HasMany(c => c.Mascotas)
                .WithMany(m => m.Cuentas)
                .UsingEntity(x => x.ToTable("CuentaMascotas"));

            builder.Entity<Cuenta>()
                .HasMany(c => c.Refugios)
                .WithMany(r => r.Cuentas)
                .UsingEntity(x => x.ToTable("CuentaRefugios"));

            builder.Entity<Mascota>()
                .HasOne(c => c.SuRefugio)
                .WithMany(u => u.Mascotas)
                .HasForeignKey(c => c.RefugioId)
                .IsRequired();
        }
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
    }
}
