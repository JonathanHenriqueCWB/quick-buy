using QuickBuy.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Domain.Entidades
{
    public class Pedido : Entidade
    {
        #region PedidoId
        public int PedidoId { get; set; }
        #endregion
        #region Data do Pedido
        public DateTime DataPedido { get; set; }
        #endregion
        #region Data Previsao Entrega
        public DateTime DataPrevisaoEntrega { get; set; }
        #endregion
        #region Usuario
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        #endregion
        #region Endereo
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        #endregion
        #region Forma Pagamento
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        #endregion

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }

        #region Método/Validate herdada da classe pai Entidade
        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItemPedidos.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(Endereco.Cep))
                AdicionarCritica("Crítica - CEP deve estar preenchido");
        }
        #endregion
    }
}