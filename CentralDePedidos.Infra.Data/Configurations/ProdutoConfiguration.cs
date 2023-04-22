using CentralDePedidos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
