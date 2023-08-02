using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ALTERAÇÃOEPOPULARTABELADETIPOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TransactionTypes",
                newName: "Signal");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TransactionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nature",
                table: "TransactionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Description", "Nature", "Signal" },
                values: new object[,]
                {
                    { 1, "Débito", "Entrada", "+" },
                    { 2, "Boleto", "Saída", "-" },
                    { 3, "Financiamento", "Saída", "-" },
                    { 4, "Crédito", "Entrada", "+" },
                    { 5, "Recebimento Empréstimo", "Entrada", "+" },
                    { 6, "Vendas", "Entrada", "+" },
                    { 7, "Recebimento TED", "Entrada", "+" },
                    { 8, "Recebimento DOC", "Entrada", "+" },
                    { 9, "Aluguel", "Saída", "-" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "Nature",
                table: "TransactionTypes");

            migrationBuilder.RenameColumn(
                name: "Signal",
                table: "TransactionTypes",
                newName: "Name");
        }
    }
}
