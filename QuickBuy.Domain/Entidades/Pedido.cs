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
        //Possivelmente ira entra uma propert FormaPagamentoId aqui!!!
        public FormaPagamento FormaPagamento { get; set; }


        //Um pedido tem que ter no minimo um ou varios ItemPedido
        public ICollection<ItemPedido> ItemPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItemPedidos.Any())
                AdicionarCritica("Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(Endereco.Cep))
                AdicionarCritica("CEP deve estar preenchido");
        }
    }
}