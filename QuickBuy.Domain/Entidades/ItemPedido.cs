namespace QuickBuy.Domain.Entidades
{
    public class ItemPedido : Entidade
    {
        #region ItemPedidoId
        public int ItemPedidoId { get; set; }
        #endregion
        #region Quantidade
        public int Quantidade { get; set; }
        #endregion
        #region Produto
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        #endregion


        public override void Validate()
        {
            LimparCritica();

            if (Quantidade == 0)
                AdicionarCritica("Quantidade não foi informada");
        }
    }
}
