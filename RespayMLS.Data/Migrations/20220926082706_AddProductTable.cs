using Microsoft.EntityFrameworkCore.Migrations;

namespace RespayMLS.Data.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Charge_ChargeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategories_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MaximumListing",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "NoOfBoosts",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "PercentageOfPrice",
                table: "Charge");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "PremiumListing",
                table: "Charge",
                newName: "SetupFee");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ChargeId",
                table: "Products",
                newName: "IX_Products_ChargeId");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaximumListing",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SetupFee",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FrequencyId",
                table: "Products",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemTypeId",
                table: "Products",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SectorId",
                table: "Products",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Charge_ChargeId",
                table: "Products",
                column: "ChargeId",
                principalTable: "Charge",
                principalColumn: "ChargeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Currencies_CurrencyId",
                table: "Products",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Frequencies_FrequencyId",
                table: "Products",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "FrequencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItemTypes_ItemTypeId",
                table: "Products",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sectors_SectorId",
                table: "Products",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Charge_ChargeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currencies_CurrencyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Frequencies_FrequencyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItemTypes_ItemTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sectors_SectorId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CurrencyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FrequencyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ItemTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SectorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaximumListing",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SetupFee",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "SetupFee",
                table: "Charge",
                newName: "PremiumListing");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Product",
                newName: "IX_Product_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ChargeId",
                table: "Product",
                newName: "IX_Product_ChargeId");

            migrationBuilder.AddColumn<double>(
                name: "MaximumListing",
                table: "Charge",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfBoosts",
                table: "Charge",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOfPrice",
                table: "Charge",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Charge_ChargeId",
                table: "Product",
                column: "ChargeId",
                principalTable: "Charge",
                principalColumn: "ChargeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategories_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
