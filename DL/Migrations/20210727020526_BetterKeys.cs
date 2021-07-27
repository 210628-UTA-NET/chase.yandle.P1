using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class BetterKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_liOrderoID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_liProductpID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_oCustomercID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_oStorestID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_oCustomercID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_oStorestID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_liOrderoID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_liProductpID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "oCustomercID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "oStorestID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "liOrderoID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "liProductpID",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "oCustomerID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oStoreID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "liOrderID",
                table: "LineItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "liProductID",
                table: "LineItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oCustomerID",
                table: "Orders",
                column: "oCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oStoreID",
                table: "Orders",
                column: "oStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liOrderID",
                table: "LineItems",
                column: "liOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liProductID",
                table: "LineItems",
                column: "liProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_liOrderID",
                table: "LineItems",
                column: "liOrderID",
                principalTable: "Orders",
                principalColumn: "oID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_liProductID",
                table: "LineItems",
                column: "liProductID",
                principalTable: "Products",
                principalColumn: "pID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_oCustomerID",
                table: "Orders",
                column: "oCustomerID",
                principalTable: "Customers",
                principalColumn: "cID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_oStoreID",
                table: "Orders",
                column: "oStoreID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_liOrderID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_liProductID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_oCustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_oStoreID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_oCustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_oStoreID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_liOrderID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_liProductID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "oCustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "oStoreID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "liOrderID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "liProductID",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "oCustomercID",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "oStorestID",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "liOrderoID",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "liProductpID",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oCustomercID",
                table: "Orders",
                column: "oCustomercID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oStorestID",
                table: "Orders",
                column: "oStorestID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liOrderoID",
                table: "LineItems",
                column: "liOrderoID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liProductpID",
                table: "LineItems",
                column: "liProductpID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_liOrderoID",
                table: "LineItems",
                column: "liOrderoID",
                principalTable: "Orders",
                principalColumn: "oID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_liProductpID",
                table: "LineItems",
                column: "liProductpID",
                principalTable: "Products",
                principalColumn: "pID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_oCustomercID",
                table: "Orders",
                column: "oCustomercID",
                principalTable: "Customers",
                principalColumn: "cID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_oStorestID",
                table: "Orders",
                column: "oStorestID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
