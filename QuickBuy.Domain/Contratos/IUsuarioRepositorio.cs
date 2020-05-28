using QuickBuy.Domain.Entidades;

namespace QuickBuy.Domain.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Verificar(string email, string senha);
        Usuario Verificar(string email);
    }
}
