using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Domain.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }

        public Entidade()
        {
            _mensagensValidacao = new List<string>();
        }
        
        public abstract void Validate();

        #region Verifica se é valido e retornar lista de erros. Utilização na API
        //Verefica se existe mensagem de erro na lista, caso sim retorna true
        public bool VerificarErros
        {
            get { return _mensagensValidacao.Any(); }
        }
        
        //Junta todas as mensagens da lista em uma só
        public string ObterMensagensValidacao()
        {
            return string.Join(". ", _mensagensValidacao);
        }
        #endregion
        #region Adicionar e remover erros. Utilização na classes filha
        //Métodos para adicionar e remover erros na lista
        protected void LimparCritica()
        {
            _mensagensValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            _mensagensValidacao.Add(mensagem);
        }
        #endregion
    }
}

/*
 * Cria uma lista para adicionar possiveis error.
 * Construtor instanciando a lista.
 * Método abstrato será implementado nas classes filha.
 * EhValido verefica se tem algum erro na lista de erros.
 * ObterMensagemValidação junta todas as strings da lista em uma só.
 * Métodos Adicionar/Remover critica para adicionar os erros a lista de erros.
 */
