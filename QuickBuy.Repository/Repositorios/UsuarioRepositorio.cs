using QuickBuy.Domain.Contratos;
using QuickBuy.Domain.Entidades;
using QuickBuy.Repository.Contexto;

namespace QuickBuy.Repository.Repositorios
{
    //Classe herda da base repositorio como da interface usuario repositorio
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto contexto) : base(contexto)
        {
        }
    }
}
