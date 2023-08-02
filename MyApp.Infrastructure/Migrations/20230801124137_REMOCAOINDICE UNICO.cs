using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class REMOCAOINDICEUNICO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerMovements_TransactionTypeId",
                table: "CustomerMovements");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovements_TransactionTypeId",
                table: "CustomerMovements",
                column: "TransactionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerMovements_TransactionTypeId",
                table: "CustomerMovements");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovements_TransactionTypeId",
                table: "CustomerMovements",
                column: "TransactionTypeId",
                unique: true,
                filter: "[TransactionTypeId] IS NOT NULL");
        }
    }
}
