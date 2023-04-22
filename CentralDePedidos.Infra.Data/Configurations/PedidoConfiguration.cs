﻿using CentralDePedidos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Infra.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Cobranca)
                .WithOne(c => c.Pedido)
                .HasForeignKey<Pedido>(p => p.CobrancaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
