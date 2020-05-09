using QuickBuy.Domain.Contratos;
using QuickBuy.Domain.Entidades;
using QuickBuy.Repository.Contexto;

namespace QuickBuy.Repository.Repositorios
{
    //Classe herda da BaseRepositorio e da interface IUsuarioRepositorio
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto contexto) : base(contexto)
        {
        }
    }
}
