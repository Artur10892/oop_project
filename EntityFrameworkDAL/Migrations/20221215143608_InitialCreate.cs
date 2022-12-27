using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkDAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Customer_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ShipmentTypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipInfos_CustomerUser",
                        column: x => x.CustomerUserId,
                        principalTable: "Customers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ShipInfoId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    OrderStatusCode = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_ShipInfo",
                        column: x => x.ShipInfoId,
                        principalTable: "ShipInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SoldQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderProducts_SalesOrder",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Віталій", "Свистун" },
                    { 2, null, new DateTime(1975, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Інокентій", "Фірташ" },
                    { 3, null, new DateTime(2000, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ярослав", "Татарчук" },
                    { 4, null, new DateTime(1901, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Йосиф", "Дмитренко" },
                    { 5, null, new DateTime(1993, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Констянтин", "Шарапенко" },
                    { 6, null, new DateTime(1984, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Олег", "Притула" },
                    { 7, null, new DateTime(1979, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анатолій", "Назаренко" },
                    { 8, null, new DateTime(1993, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микола", "Вакуленко" },
                    { 9, null, new DateTime(1994, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Степан", "Барабаш" },
                    { 10, null, new DateTime(1997, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Денис", "Ярема" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "UserId",
                values: new object[]
                {
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "ShipInfo",
                columns: new[] { "Id", "CustomerUserId", "LocationId", "ShipmentTypeCode" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 3, 2, 1 },
                    { 3, 4, 4, 1 },
                    { 4, 4, 6, 2 },
                    { 5, 5, 8, 1 },
                    { 6, 2, 9, 3 },
                    { 7, 6, 10, 1 },
                    { 8, 7, 12, 2 },
                    { 9, 8, 14, 1 },
                    { 10, 9, 15, 1 },
                    { 11, 10, 17, 3 },
                    { 12, 7, 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "Date", "OrderStatusCode", "ShipInfoId", "TotalPrice", "WarehouseId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 295m, 1 },
                    { 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 276m, 3 },
                    { 3, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 988m, 1 },
                    { 4, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 609m, 1 },
                    { 5, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 486m, 2 },
                    { 6, new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1401m, 3 },
                    { 7, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 534m, 1 },
                    { 8, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, 405m, 3 },
                    { 9, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 520m, 3 },
                    { 10, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 316m, 2 }
                });

            migrationBuilder.InsertData(
                table: "SalesOrderProducts",
                columns: new[] { "Id", "ProductId", "SalesOrderId", "SoldQuantity" },
                values: new object[,]
                {
                    { 1, 5, 1, 1 },
                    { 2, 11, 1, 1 },
                    { 3, 9, 1, 2 },
                    { 4, 2, 2, 3 },
                    { 5, 12, 2, 6 },
                    { 6, 11, 3, 2 },
                    { 7, 8, 3, 6 },
                    { 8, 5, 3, 2 },
                    { 9, 6, 3, 3 },
                    { 10, 1, 4, 4 },
                    { 11, 8, 4, 7 },
                    { 12, 4, 5, 6 },
                    { 13, 5, 6, 4 },
                    { 14, 2, 6, 1 },
                    { 15, 7, 6, 11 },
                    { 16, 10, 6, 3 },
                    { 17, 8, 7, 8 },
                    { 18, 3, 7, 2 },
                    { 19, 4, 8, 5 },
                    { 20, 8, 9, 12 },
                    { 21, 9, 9, 4 },
                    { 22, 5, 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderProducts_SalesOrderId",
                table: "SalesOrderProducts",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ShipInfoId",
                table: "SalesOrders",
                column: "ShipInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipInfo_CustomerUserId",
                table: "ShipInfo",
                column: "CustomerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrderProducts");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "ShipInfo");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
