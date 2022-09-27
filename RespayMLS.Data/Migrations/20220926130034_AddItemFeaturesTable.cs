using Microsoft.EntityFrameworkCore.Migrations;

namespace RespayMLS.Data.Migrations
{
    public partial class AddItemFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemFeatures",
                columns: table => new
                {
                    ItemFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFeatures", x => x.ItemFeatureId);
                    table.ForeignKey(
                        name: "FK_ItemFeatures_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubFeatures",
                columns: table => new
                {
                    ItemSubFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSubFeatureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubFeatures", x => x.ItemSubFeatureId);
                    table.ForeignKey(
                        name: "FK_ItemSubFeatures_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubTypes",
                columns: table => new
                {
                    ItemSubTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubTypes", x => x.ItemSubTypeId);
                    table.ForeignKey(
                        name: "FK_ItemSubTypes_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemFeatures_SectorId",
                table: "ItemFeatures",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubFeatures_SectorId",
                table: "ItemSubFeatures",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubTypes_SectorId",
                table: "ItemSubTypes",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemFeatures");

            migrationBuilder.DropTable(
                name: "ItemSubFeatures");

            migrationBuilder.DropTable(
                name: "ItemSubTypes");
        }
    }
}
