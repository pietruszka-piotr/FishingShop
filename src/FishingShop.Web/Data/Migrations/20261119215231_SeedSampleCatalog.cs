using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingShop.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wędki" },
                    { 2, "Kołowrotki" },
                    { 3, "Przynęty" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RiverTrail" },
                    { 2, "LakePoint" },
                    { 3, "ReedCraft" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Description", "Price", "CategoryId", "BrandId" },
                values: new object[,]
                {
                    { 1, "Wędka spinningowa 240",
                        "Uniwersalna wędka o długości 2,40 m do łowienia na spinning.",
                        149.90m, 1, 1 },
                    { 2, "Kołowrotek 2500",
                        "Kołowrotek z przednim hamulcem do lekkiego łowienia spinningowego.",
                        189.00m, 2, 2 },
                    { 3, "Błystka obrotowa nr 2",
                        "Obrotowa przynęta o masie 5 g do łowienia okoni i pstrągów.",
                        12.50m, 3, 3 },
                    { 4, "Wędka castingowa 240",
                        "Wędka castingowa o długości 2,40 m i ciężarze wyrzutowym 7-21 g.",
                        229.90m, 1, 2 },
                    { 5, "Wędka spinningowa 210",
                        "Lekka wędka o długości 2,10 m i ciężarze wyrzutowym 2-10 g.",
                        129.00m, 1, 3 },
                    { 6, "Wędka castingowa 198",
                        "Krótka wędka castingowa o długości 1,98 m i ciężarze wyrzutowym 10-30 g.",
                        249.00m, 1, 1 },
                    { 7, "Kołowrotek 1000",
                        "Kompaktowy kołowrotek do łowienia na lekkie przynęty.",
                        149.00m, 2, 1 },
                    { 8, "Kołowrotek 4000",
                        "Kołowrotek z pojemną szpulą do cięższego łowienia spinningowego.",
                        249.90m, 2, 3 },
                    { 9, "Multiplikator castingowy",
                        "Multiplikator o niskim profilu do wędki castingowej.",
                        299.00m, 2, 2 },
                    { 10, "Wobler 7 cm",
                        "Pływający wobler o długości 7 cm do łowienia szczupaków.",
                        24.90m, 3, 2 },
                    { 11, "Guma 8 cm",
                        "Miękka przynęta o długości 8 cm do zbrojenia w główkę jigową.",
                        4.50m, 3, 1 },
                    { 12, "Błystka wahadłowa 18 g",
                        "Metalowa przynęta o masie 18 g do łowienia szczupaków.",
                        14.90m, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "RodSpecifications",
                columns: new[] { "ProductId", "LengthCm", "CastWeightMinG", "CastWeightMaxG", "Type" },
                values: new object[,]
                {
                    { 1, 240, 10m, 30m, "Spinning" },
                    { 4, 240, 7m, 21m, "Casting" },
                    { 5, 210, 2m, 10m, "Spinning" },
                    { 6, 198, 10m, 30m, "Casting" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RodSpecifications",
                keyColumn: "ProductId",
                keyValues: new object[] { 1, 4, 5, 6 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
