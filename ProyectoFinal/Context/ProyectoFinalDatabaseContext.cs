
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
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
    }
}
