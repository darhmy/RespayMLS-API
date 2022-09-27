using Microsoft.EntityFrameworkCore.Migrations;

namespace RespayMLS.Data.Migrations
{
    public partial class AjustItemSubTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSubTypes_Sectors_SectorId",
                table: "ItemSubTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemSubTypes_SectorId",
                table: "ItemSubTypes");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "ItemSubTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "ItemSubTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubTypes_SectorId",
                table: "ItemSubTypes",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSubTypes_Sectors_SectorId",
                table: "ItemSubTypes",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
