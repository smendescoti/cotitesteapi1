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
    public class CobrancaConfiguration : IEntityTypeConfiguration<Cobranca>
    {
        public void Configure(EntityTypeBuilder<Cobranca> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}
