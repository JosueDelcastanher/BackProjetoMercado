using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DELIVERY_MAN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SALARY = table.Column<double>(type: "FLOAT", nullable: false),
                    PIS = table.Column<string>(type: "CHAR(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_MAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESTAURANT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(18)", nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTAURANT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(255)", maxLength: 16, nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SNACK",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PRICE = table.Column<double>(type: "FLOAT", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNACK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SNACK_RESTAURANT_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RESTAURANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    STATE = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NEIGHBORHOOD = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    STREET = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NUMBER = table.Column<string>(type: "VARCHAR(6)", nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ADDRESS_RESTAURANT_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RESTAURANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMMENT_RESTAURANT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    RestaurantId = table.Column<int>(nullable: false),
                    COMENTARIO = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsGood = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT_RESTAURANT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMMENT_RESTAURANT_RESTAURANT_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RESTAURANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMENT_RESTAURANT_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    DATE = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<int>(nullable: false),
                    DeliveryManId = table.Column<int>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DELIVERY_MAN_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "DELIVERY_MAN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_RESTAURANT_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RESTAURANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS_SNACKS",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS_SNACKS", x => new { x.OrderId, x.SnackId });
                    table.ForeignKey(
                        name: "FK_ORDERS_SNACKS_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_SNACKS_SNACK_SnackId",
                        column: x => x.SnackId,
                        principalTable: "SNACK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_RestaurantId",
                table: "ADDRESS",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RESTAURANT_RestaurantId",
                table: "COMMENT_RESTAURANT",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RESTAURANT_UserId",
                table: "COMMENT_RESTAURANT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DeliveryManId",
                table: "ORDER",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_RestaurantId",
                table: "ORDER",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_UserId",
                table: "ORDER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SNACKS_SnackId",
                table: "ORDERS_SNACKS",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_SNACK_RestaurantId",
                table: "SNACK",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "COMMENT_RESTAURANT");

            migrationBuilder.DropTable(
                name: "ORDERS_SNACKS");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "SNACK");

            migrationBuilder.DropTable(
                name: "DELIVERY_MAN");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "RESTAURANT");
        }
    }
}
