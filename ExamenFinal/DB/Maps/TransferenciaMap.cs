using ExamenFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.DB.Maps
{
    public class TransferenciaMap : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(o => o.Id_Transferencia);

            //builder.HasOne(o => o.Producto).WithMany(o => o.Carrito_Pedidos).HasForeignKey(o => o.Id_Producto);
        }
    }
}