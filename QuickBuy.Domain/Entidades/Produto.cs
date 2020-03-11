namespace QuickBuy.Domain.Entidades
{
    public class Produto : Entidade
    {
        #region ProdutoId
        public int ProdutoId { get; set; }
        #endregion
        #region Nome
        public string Nome { get; set; }
        #endregion
        #region Descricao
        public string Descricao { get; set; }
        #endregion
        #region Preco
        public decimal Preco { get; set; }
        #endregion

        #region Validade da classe pai Entidades
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
