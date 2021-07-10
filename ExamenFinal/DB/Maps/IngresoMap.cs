using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.DB.Maps
{
    public class IngresoMap : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.ToTable("Ingreso");
            builder.HasKey(o => o.Id_Ingreso);

            //builder.HasOne(o => o.Usuario).WithMany(o => o.Carrito_Pedidos).HasForeignKey(o => o.Id_Usuario);
            //builder.HasOne(o => o.Producto).WithMany(o => o.Carrito_Pedidos).HasForeignKey(o => o.Id_Producto);
        }
    }
}