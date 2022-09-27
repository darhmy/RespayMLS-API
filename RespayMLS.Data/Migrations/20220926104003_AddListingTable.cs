using Microsoft.EntityFrameworkCore.Migrations;

namespace RespayMLS.Data.Migrations
{
    public partial class AddListingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItemTypes_ItemTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Products",
                newName: "PlanTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ItemTypeId",
                table: "Products",
                newName: "IX_Products_PlanTypeId");

            migrationBuilder.CreateTable(
                name: "ListingTypes",
                columns: table => new
                {
                    ListingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platforms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingTypes", x => x.ListingTypeId);
                    table.ForeignKey(
                        name: "FK_ListingTypes_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListingTypes_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingTypes_RoleId",
                table: "ListingTypes",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingTypes_SectorId",
                table: "ListingTypes",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PlanTypes_PlanTypeId",
                table: "Products",
                column: "PlanTypeId",
                principalTable: "PlanTypes",
                principalColumn: "PlanTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PlanTypes_PlanTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ListingTypes");

            migrationBuilder.RenameColumn(
                name: "PlanTypeId",
                table: "Products",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PlanTypeId",
                table: "Products",
                newName: "IX_Products_ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItemTypes_ItemTypeId",
                table: "Products",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
