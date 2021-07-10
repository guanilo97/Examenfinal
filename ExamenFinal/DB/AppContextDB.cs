using ExamenFinal.DB.Maps;
using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.DB
{
    public class AppContextDB : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactoMap());
            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new GastoMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new SolicitudMap());
            modelBuilder.ApplyConfiguration(new TransferenciaMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}

