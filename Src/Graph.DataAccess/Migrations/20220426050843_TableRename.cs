using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graph.DataAccess.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoAsset",
                table: "CryptoAsset");

            migrationBuilder.RenameTable(
                name: "CryptoAsset",
                newName: "CryptoAssets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoAssets",
                table: "CryptoAssets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoAssets",
                table: "CryptoAssets");

            migrationBuilder.RenameTable(
                name: "CryptoAssets",
                newName: "CryptoAsset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoAsset",
                table: "CryptoAsset",
                column: "Id");
        }
    }
}
