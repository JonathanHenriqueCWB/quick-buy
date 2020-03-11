using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickBuy.Domain.Entidades
{
    public class Usuario : Entidade
    {
        #region UsuarioId
        public int UsuarioId { get; set; }
        #endregion
        #region Nome
        public string Nome { get; set; }
        #endregion
        #region Sobre Nome
        public string SobreNome { get; set; }
        #endregion
        #region Email
        public string Email { get; set; }
        #endregion
        #region Senha
        public string Senha { get; set; }
        #endregion
        #region Confirma senha
        [Display(Name = "Confirmação da senha:")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        public string ConfirmaSenha { get; set; }
        #endregion

        public virtual ICollection<Pedido> Pedidos { get; set; }

        #region Método/Função Validade implementado da classe pai Entidade
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
