using QuickBuy.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Domain.Entidades
{
    public class Pedido : Entidade
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public ICollection<ItemPedido> ItemPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItemPedidos.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(Endereco.Cep))
                AdicionarCritica("Crítica - CEP deve estar preenchido");
        }
    }
}