using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repository.Config
{
    class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId) ;

            //Builder utliza o padão fluent
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(400);
            builder.Property(p => p.Preco).HasColumnType("decimal(19,4)").IsRequired();
        }
    }
}
