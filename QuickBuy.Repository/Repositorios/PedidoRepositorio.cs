using QuickBuy.Domain.Entidades;
using QuickBuy.Domain.Contratos;
using QuickBuy.Repository.Contexto;

namespace QuickBuy.Repository.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(QuickBuyContexto contexto) : base(contexto)
        {
        }
    }
}
