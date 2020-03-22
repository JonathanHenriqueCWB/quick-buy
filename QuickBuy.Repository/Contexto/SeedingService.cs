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

            if (_contexto.FormaPagamentos.Any())
            {
                return;
            }

            FormaPagamento f1 = new FormaPagamento()
            {
                FormaPagamentoId = 1,
                Nome = "Boleto",
                Descricao = "Forma de pagamento Boleto"
            };

            FormaPagamento f2 = new FormaPagamento()
            {
                FormaPagamentoId = 2,
                Nome = "Cartão de Credito",
                Descricao = "Forma de pagamento Cartão de Credito"
            };

            FormaPagamento f3 = new FormaPagamento
            {
                FormaPagamentoId = 3,
                Nome = "Deposito",
                Descricao = "Forma de pagamento Deposito"
            };

            _contexto.FormaPagamentos.AddRange(f1, f2, f3);
            _contexto.SaveChanges();
        }
    }
}

/*
 * Classe serve como apoio para o sitema, populara alguns dados já definidos
 * para base de dados, ou seja, dados que precisam ser inseridos
 * para o funcionamento do sistema inicialmente.
 * 
 * Esse processo só será executado quando inicar o projeto pela 
 * primeira vez, diferente da carga do contexto que gera uma 
 * migration e sobe junto com banco de dados.
 */
