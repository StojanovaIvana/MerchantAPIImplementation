using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchantApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Merchants_MerchantCodeMerchantId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MerchantCodeMerchantId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MerchantCodeMerchantId",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "MerchantCode",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MerchantId",
                table: "Stores",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Merchants_MerchantId",
                table: "Stores",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Merchants_MerchantId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MerchantId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MerchantCode",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "MerchantCodeMerchantId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MerchantCodeMerchantId",
                table: "Stores",
                column: "MerchantCodeMerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Merchants_MerchantCodeMerchantId",
                table: "Stores",
                column: "MerchantCodeMerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
