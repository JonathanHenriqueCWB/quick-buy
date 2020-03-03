using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entidades
{
    //Classe abstrata não precisa ser instanciada
    public abstract class Entidade
    {
        //Properties
        private List<string> _mensagensValidacao { get; set; }

        private List<string> mensagemValidacao {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
         }

        protected bool EhValidado
        {
            get { return !mensagemValidacao.Any(); }
        }

        //Métodos/Função abstratos
        public abstract void Validate();

        //Método/Função
        protected void LimparMensagemValidacao()
        {
            mensagemValidacao.Clear();
        }
        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
    }
}
