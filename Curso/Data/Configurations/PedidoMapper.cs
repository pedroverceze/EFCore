using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoConsole.Domain;

namespace Curso.Data.Configurations
{
    public class PedidoMapper : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.TipoFrete).HasConversion<int>();

                //relacionamento 1-N muitos Itens para um pedido
            builder.HasMany(p => p.Itens)
                    .WithOne(p => p.Pedido)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}