using QuickBuy.Domain.ObjetoDeValor;
using System.Linq;

namespace QuickBuy.Repository.Contexto
{
    public class SeedingService
    {
        private readonly QuickBuyContexto _contexto;
        public SeedingService(QuickBuyContexto contexto)
        {
            _contexto = contexto;
        }

        public void Seed()
        {
            //É necessário testar para ver se a tabela já está populada
            if (_contexto.FormaPagamentos.Any())
            {
                return;
            }

            FormaPagamento fm1 = new FormaPagamento(1, "Boleto", "Forma de pagamento Boleto");
            FormaPagamento fm2 = new FormaPagamento(2, "Cartao de Credito", "Forma de pagamento Cartao");
            FormaPagamento fm3 = new FormaPagamento(3, "Deposito", "Forma de pagamento Deposito");

            //_contexto.FormaPagamentos.AddRange(fm1, fm2, fm3);
            //_contexto.SaveChanges();
        }
    }
}

    /*
     * Classe serve como apoio para o sitema, populara alguns dados já definidos
     * para base de dados, ou seja, dados que precisam ser inseridos
     * para o funcionamento do sistema inicialmente.
     * 
     */
