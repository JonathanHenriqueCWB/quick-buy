using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repository.Migrations
{
    public partial class CargaFormaPagamentoContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "FormaPagamentoId", "Descricao", "Nome" },
                values: new object[] { 1, "Forma de pagamento Boleto", "Boleto" });

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "FormaPagamentoId", "Descricao", "Nome" },
                values: new object[] { 2, "Forma de pajgamento Cartão de Credito", "Cartão de Credito" });

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "FormaPagamentoId", "Descricao", "Nome" },
                values: new object[] { 3, "Forma de pagamento Boleto", "Boleto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "FormaPagamentoId",
                keyValue: 3);
        }
    }
}
