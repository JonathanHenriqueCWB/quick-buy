using System.Collections.Generic;

namespace QuickBuy.Domain.Entidades
{
    public abstract class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ComfirmaSenha { get; set; }

        //Um usuario pode ter nenhum ou varios pedidos
        public ICollection<Pedido> Pedidos { get; set; }


    }
}
