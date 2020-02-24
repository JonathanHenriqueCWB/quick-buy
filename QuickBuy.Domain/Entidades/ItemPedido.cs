namespace QuickBuy.Domain.Entidades
{
    public class ItemPedido : Entidade
    {
        public int ItemPedidoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
