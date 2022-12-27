using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch_Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocalAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Region",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Location",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Консерви", "Консерви" },
                    { 2, "Соєві продукти", "Соєві продукти" },
                    { 3, "Риба", "Риба" },
                    { 4, "М'ясо", "М'ясо" },
                    { 5, "Посуд", "Посуд" },
                    { 6, "Гриби", "Гриби" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Київська" },
                    { 2, "Вінницька" },
                    { 3, "Волинська" },
                    { 4, "Дніпропетровська" },
                    { 5, "Донецька" },
                    { 6, "Житомирська" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "LocalAddress", "RegionId" },
                values: new object[,]
                {
                    { 1, "Київ", "вул. Максимовича", 1 },
                    { 2, "Київ", "бул. Дарницький", 1 },
                    { 3, "Бережан", "вул. Радісна", 1 },
                    { 4, "Бориспіль", "вул. Хвойна", 1 },
                    { 5, "Київ", "пров. Майкопський", 1 },
                    { 6, "Вінниця", "вул. Бучми", 2 },
                    { 7, "Жмеринка", "пров. Вишневий", 2 },
                    { 8, "Могилев-Подільський", "вул. Генетична", 2 },
                    { 9, "Хмільник", "вул. О. Кошового", 2 },
                    { 10, "Луцьк", "вул. Панаса Мирного", 3 },
                    { 11, "Володимир-Волинський", "пров. Наливайка", 3 },
                    { 12, "Луцьк", "просп. Веселий", 3 },
                    { 13, "Дніпро", "вул. Аксакова", 4 },
                    { 14, "Вільногірськ", "вул. Єлісеївська", 4 },
                    { 15, "Кам`янське", "вул. Космонавтів", 4 },
                    { 16, "Нікополь", "вул. Басейна", 4 },
                    { 17, "Житомир", "бул. Європейський", 5 },
                    { 18, "Бердячів", "вул. Якубця", 5 },
                    { 19, "Коростень", "вул. Гайдамацька", 5 },
                    { 20, "Малин", "вул. Левінська", 5 },
                    { 21, "Київ", "вул. Ясна", 1 },
                    { 22, "Дніпро", "вул. Чернишевського", 4 },
                    { 23, "Луцьк", "вул. Потапова", 3 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CompanyName", "LocationId", "PhoneNum" },
                values: new object[,]
                {
                    { 1, "ТОВ 'Кернел-Трейд'", 3, "+380955017222" },
                    { 2, "ДП 'Гарантований покупець'", 5, "+380506952890" },
                    { 3, "ПрАТ 'ММК Ім. Ілліча'", 7, "+380950668956" },
                    { 4, "ТОВ 'Сільпо-Фуд'", 11, "+380959304515" },
                    { 5, "ТОВ 'Епіцентр К'", 13, "+380504425483" },
                    { 6, "ТОВ 'БАДМ'", 16, "+380958437543" },
                    { 7, "ТОВ 'ХІМ-Трейд'", 18, "+380981064707" },
                    { 8, "ПрАТ 'МХП'", 19, "+380926244083" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "PurchasePrice", "SellPrice", "SupplierId" },
                values: new object[,]
                {
                    { 1, 2, "", null, "Соєва ковбаса (шт.)", 83m, 91m, 3 },
                    { 2, 2, "", null, "Соєвий соус (шт.)", 20m, 38m, 3 },
                    { 3, 3, "", null, "Карась річний (шт.)", 102m, 127m, 6 },
                    { 4, 5, "", null, "Тарілка (шт.)", 57m, 81m, 1 },
                    { 5, 5, "", null, "Набір ложок (шт.)", 121m, 158m, 5 },
                    { 6, 1, "", null, "Консервовані огірки (шт.)", 83m, 96m, 4 },
                    { 7, 4, "", null, "Яловичина (кг)", 19m, 46m, 2 },
                    { 8, 4, "", null, "Свинина (кг)", 28m, 35m, 3 },
                    { 9, 6, "", null, "Шампіньйони (кг.)", 20m, 25m, 7 },
                    { 10, 5, "", null, "Дошка для нарізання (шт.)", 58m, 75m, 8 },
                    { 11, 3, "", null, "Хек в'ялений (шт.)", 70m, 87m, 6 },
                    { 12, 6, "", null, "Гливи (кг.)", 17m, 27m, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId",
                table: "Locations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LocationId",
                table: "Suppliers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProducts_ProductId",
                table: "WarehouseProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
