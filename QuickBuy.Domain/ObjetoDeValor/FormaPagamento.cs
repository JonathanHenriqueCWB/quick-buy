using QuickBuy.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.ObjetoDeValor
{
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        public bool EhBoleto
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.Boleto; }
        }
        public bool EhCartaoCredito
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.Cartao; }
        }
        public bool EhDeposito
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.Deposito; }
        }
        public bool NaoFoiDefinido
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }
    }
}

    /*
     *     Classe que serve de apoio a classe pedido, por isso não foi considerado]
     *     uma entidade, as propriedades EhBoleto, EhCartaoCredito, EhDeposito, ou 
     *     não definido definirá o tipo de pagamento, caso id da classe seja igual o
     *     valor do enum correspondente
     */
