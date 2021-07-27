using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductpID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Stores_StorestID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductpID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StorestID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductpID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "StorestID",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "iProduct",
                table: "Inventories",
                newName: "iProductID");

            migrationBuilder.RenameColumn(
                name: "iStore",
                table: "Inventories",
                newName: "iStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_iProductID",
                table: "Inventories",
                column: "iProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_iProductID",
                table: "Inventories",
                column: "iProductID",
                principalTable: "Products",
                principalColumn: "pID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Stores_iStoreID",
                table: "Inventories",
                column: "iStoreID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_iProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Stores_iStoreID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_iProductID",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "iProductID",
                table: "Inventories",
                newName: "iProduct");

            migrationBuilder.RenameColumn(
                name: "iStoreID",
                table: "Inventories",
                newName: "iStore");

            migrationBuilder.AddColumn<int>(
                name: "ProductpID",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorestID",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductpID",
                table: "Inventories",
                column: "ProductpID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StorestID",
                table: "Inventories",
                column: "StorestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductpID",
                table: "Inventories",
                column: "ProductpID",
                principalTable: "Products",
                principalColumn: "pID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Stores_StorestID",
                table: "Inventories",
                column: "StorestID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
