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
        #region Lista de pedidos
        public virtual ICollection<Pedido> Pedidos { get; set; }
        #endregion

        public override void Validate()
        {
            LimparCritica();

            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome não foi informado");
            if (string.IsNullOrEmpty(SobreNome))
                AdicionarCritica("Sobre nome não foi informado");
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("Eamil não informado");
            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Senha não foi informado");
            if (Senha != ConfirmaSenha)
                AdicionarCritica("As senha devem ser igual");
        }
    }
}
