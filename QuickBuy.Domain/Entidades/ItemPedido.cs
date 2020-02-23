namespace QuickBuy.Domain.Entidades
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
