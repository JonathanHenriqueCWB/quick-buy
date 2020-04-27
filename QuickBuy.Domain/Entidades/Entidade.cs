using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Domain.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao {  
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); } 
        }

        public abstract void Validate();

        protected bool EhValidado
        {
            get { return !mensagemValidacao.Any(); }
        }        

        protected void LimparCritica()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
    }
}

/*
 * Classe Entidade server para poder fazer a validação as regras de negócio
 * para cada uma das entidade que a implementarem
 * 
 * Propriedade _mensagemValidação é uma lista que guardará todas mensagems de violação,
 * casso as exigências das regras de négocio da classe que a implementarem não forem 
 * atendidas.
 * 
 * mensagemValidacao  será chamada pela propriedade EhValidado,
 * e ela retornara as mensagems de validação, caso já exista alguma, ou instanciara
 * a lista e a retornará, que servirá par adicionar as violação de regra de negócio.
 * 
 * Propriedade EhValido retorna um valor booleano para quem o chamar, retornará true
 * caso não tenha nehuma mensagem de validação em _mensagemValidacao, ou seja, 
 * não tenha erros,nesse caso se não tiver mensagem de violação a calsse e considerada valida,
 * ou false caso tenha alguma mensagem de validação na lista, nesse
 * caso as exigências da classe que as implementou não foram atendidas e a classe não 
 * é valida.
 * 
 * Método abstrato validade será implementado pelas classes filhas, e servirá para
 * manipular os método LimparMensagemValidacao e AdicionarCritica. Servirá para add
 * as regras de negócio.
 */
