using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entidades;

namespace QuickBuy.Repository.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.PedidoId);
            builder.Property(p => p.DataPedido).IsRequired();
            builder.Property(p => p.DataPrevisaoEntrega).IsRequired();
            builder.HasOne(p => p.FormaPagamento);
        }
    }
}
