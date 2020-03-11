using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.Entidades
{
    public class Endereco : Entidade
    {
        #region EnderecoId
        public int EnderecoId { get; set; }
        #endregion
        #region Logradouro
        public string Logradouro { get; set; }
        #endregion
        #region CEP
        public string Cep { get; set; }
        #endregion
        #region Bairro
        public string Bairro { get; set; }
        #endregion
        #region Localidade
        public string Localidade { get; set; }
        #endregion
        #region UF
        public string Uf { get; set; }
        #endregion

        #region Método/Função validate Herdado da classe pai Entidade
        public override void Validate()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
