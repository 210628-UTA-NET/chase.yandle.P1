using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cName = table.Column<string>(type: "text", nullable: true),
                    cStreet = table.Column<string>(type: "text", nullable: true),
                    cCity = table.Column<string>(type: "text", nullable: true),
                    cState = table.Column<string>(type: "text", nullable: true),
                    cPhone = table.Column<string>(type: "text", nullable: true),
                    cEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    pID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    pName = table.Column<string>(type: "text", nullable: true),
                    pReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.pID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    stID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stStreet = table.Column<string>(type: "text", nullable: true),
                    stCity = table.Column<string>(type: "text", nullable: true),
                    stState = table.Column<string>(type: "text", nullable: true),
                    stPhone = table.Column<string>(type: "text", nullable: true),
                    stEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.stID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    iStore = table.Column<int>(type: "integer", nullable: false),
                    iProduct = table.Column<int>(type: "integer", nullable: false),
                    iQuantity = table.Column<int>(type: "integer", nullable: false),
                    ProductpID = table.Column<int>(type: "integer", nullable: true),
                    StorestID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.iStore, x.iProduct });
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductpID",
                        column: x => x.ProductpID,
                        principalTable: "Products",
                        principalColumn: "pID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_StorestID",
                        column: x => x.StorestID,
                        principalTable: "Stores",
                        principalColumn: "stID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    oID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oCustomercID = table.Column<int>(type: "integer", nullable: true),
                    oSourcestID = table.Column<int>(type: "integer", nullable: true),
                    oDestinationstID = table.Column<int>(type: "integer", nullable: true),
                    oPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    oDateAndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.oID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_oCustomercID",
                        column: x => x.oCustomercID,
                        principalTable: "Customers",
                        principalColumn: "cID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_oDestinationstID",
                        column: x => x.oDestinationstID,
                        principalTable: "Stores",
                        principalColumn: "stID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_oSourcestID",
                        column: x => x.oSourcestID,
                        principalTable: "Stores",
                        principalColumn: "stID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    liID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    liOrderoID = table.Column<int>(type: "integer", nullable: true),
                    liProductpID = table.Column<int>(type: "integer", nullable: true),
                    liQuantity = table.Column<int>(type: "integer", nullable: false),
                    liLinePrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.liID);
                    table.ForeignKey(
                        name: "FK_LineItems_Orders_liOrderoID",
                        column: x => x.liOrderoID,
                        principalTable: "Orders",
                        principalColumn: "oID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItems_Products_liProductpID",
                        column: x => x.liProductpID,
                        principalTable: "Products",
                        principalColumn: "pID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductpID",
                table: "Inventories",
                column: "ProductpID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StorestID",
                table: "Inventories",
                column: "StorestID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liOrderoID",
                table: "LineItems",
                column: "liOrderoID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_liProductpID",
                table: "LineItems",
                column: "liProductpID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oCustomercID",
                table: "Orders",
                column: "oCustomercID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oDestinationstID",
                table: "Orders",
                column: "oDestinationstID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_oSourcestID",
                table: "Orders",
                column: "oSourcestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
