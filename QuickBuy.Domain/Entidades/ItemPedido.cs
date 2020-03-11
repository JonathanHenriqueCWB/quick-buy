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

        #region Método/Função validade herdado da classe pai Entidade
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
