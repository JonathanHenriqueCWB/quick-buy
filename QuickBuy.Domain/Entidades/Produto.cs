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
        
        public override void Validate()
        {
            LimparCritica();

            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome não informado");
            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não informado");
            if (Preco == 0)
                AdicionarCritica("Preço não informado");
        }
    }
}

