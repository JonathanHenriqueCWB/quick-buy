using QuickBuy.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace QuickBuy.Domain.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public FormaPagamento FormaPagamento { get; set; }


        //Um pedido tem que ter no minimo um ou varios ItemPedido
        public ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}