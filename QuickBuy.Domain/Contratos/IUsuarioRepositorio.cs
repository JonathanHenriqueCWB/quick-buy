using QuickBuy.Domain.Entidades;

namespace QuickBuy.Domain.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario ValidarLogin(string email, string senha);
    }
}
