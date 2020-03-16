using Microsoft.EntityFrameworkCore;
using QuickBuy.Domain.Entidades;
using QuickBuy.Domain.ObjetoDeValor;
using QuickBuy.Repository.Config;

namespace QuickBuy.Repository.Contexto
{
    public class QuickBuyContexto : DbContext
    {
        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Classes de mapeamento aqui..
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            #endregion
            #region Carga inicial FormaPagamento
            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento()
            {
                FormaPagamentoId = 1,
                Nome = "Boleto",
                Descricao = "Forma de pagamento Boleto"
            },
            new FormaPagamento()
            {
                FormaPagamentoId = 2,
                Nome = "Cartão de Credito",
                Descricao = "Forma de pagamento Cartão de Credito"
            },
            new FormaPagamento
            {
                FormaPagamentoId = 3,
                Nome = "Boleto",
                Descricao = "Forma de pagamento Boleto"
            }); ;
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
    Classe de contexto, responssavel por mapear e configurar
    a base de dados
*/
