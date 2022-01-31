using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoConsole.Domain;

namespace Curso.Data.Configurations
{
    public class ClienteMapper : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
                builder.ToTable("Clientes");
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                builder.Property(c => c.Estado).HasColumnType("CHAR(2)");
        }
    }
}