using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class RemoveRestock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_oDestinationstID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_oSourcestID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_oDestinationstID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "oDestinationstID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "oSourcestID",
                table: "Orders",
                newName: "oStorestID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_oSourcestID",
                table: "Orders",
                newName: "IX_Orders_oStorestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_oStorestID",
                table: "Orders",
                column: "oStorestID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_oStorestID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "oStorestID",
                table: "Orders",
                newName: "oSourcestID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_oStorestID",
                table: "Orders",
                newName: "IX_Orders_oSourcestID");

            migrationBuilder.AddColumn<int>(
                name: "oDestinationstID",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oDestinationstID",
                table: "Orders",
                column: "oDestinationstID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_oDestinationstID",
                table: "Orders",
                column: "oDestinationstID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_oSourcestID",
                table: "Orders",
                column: "oSourcestID",
                principalTable: "Stores",
                principalColumn: "stID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
