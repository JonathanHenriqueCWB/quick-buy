using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.ObjetoDeValor;
using System;

namespace QuickBuy.Repository.Config
{
    class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(fp => fp.FormaPagamentoId);

            //Builder utliza o padão fluent
            builder.Property(fp => fp.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(fp => fp.Descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

/*
    Essas são as classes de mapeamento, que irá definir os tipos
    de propriedades das entidades exe: tamanho, maximo de caractere
    tipo da coluna no banco. Configurações gerais das tabelas do
    banco de dados.
    Herdam da classe IEntityTypeConfiguration do EntityFrameworkCore,
    e são tipadas da entidade corespondente.
    Devem ser colocadas na classe de contexto.
    
*/
