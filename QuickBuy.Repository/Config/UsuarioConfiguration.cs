using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entidades;

namespace QuickBuy.Repository.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.UsuarioId);

            //Builder utliza o padão fluent
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.SobreNome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(400);

            //HasMany varios pedidos, WithOne um unico usuário
            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario);
        }
    }
}
