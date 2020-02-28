using System.Collections.Generic;

namespace QuickBuy.Domain.Entidades
{
    public class Usuario : Entidade
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ComfirmaSenha { get; set; }        
        public ICollection<Pedido> Pedidos { get; set; } //Um usuario pode ter varios pedidos

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
