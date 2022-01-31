using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoConsole.Domain;

namespace Curso.Data.Configurations
{
    public class PedidoItemMapper : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
        }
    }
}