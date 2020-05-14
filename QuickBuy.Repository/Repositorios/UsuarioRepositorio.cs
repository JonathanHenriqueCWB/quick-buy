using QuickBuy.Domain.Contratos;
using QuickBuy.Domain.Entidades;
using QuickBuy.Repository.Contexto;
using System.Linq;

namespace QuickBuy.Repository.Repositorios
{
    //Classe herda da BaseRepositorio e da interface IUsuarioRepositorio
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto contexto) : base(contexto)
        {
        }
        public Usuario ValidarLogin(string email, string senha)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
