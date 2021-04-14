using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendChallenge.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchange",
                columns: table => new
                {
                    CurrencyExchangeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyId_From = table.Column<int>(nullable: false),
                    CurrencyId_To = table.Column<int>(nullable: false),
                    Equivalent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchange", x => x.CurrencyExchangeId);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 1, "EUR", "European euro" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 2, "USD", "United States dollar" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 3, "CAD", "Canadian dollar" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 4, "JPY", "Japanese yen" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 5, "AUD", "Australian dollar" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[] { 6, "PEN", "Peruvian sol" });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 17, 4, 2, 0.0092999999999999992 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 18, 4, 3, 0.012999999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 19, 4, 5, 0.012999999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 20, 4, 6, 0.033000000000000002 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 21, 5, 1, 0.60999999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 22, 5, 2, 0.68999999999999995 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 25, 5, 6, 2.4399999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 24, 5, 4, 74.310000000000002 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 16, 4, 1, 0.0083000000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 26, 6, 1, 0.25 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 27, 6, 2, 0.28000000000000003 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 28, 6, 3, 0.29999999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 23, 5, 3, 0.93999999999999995 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 15, 3, 6, 2.6000000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 12, 3, 2, 0.73999999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 13, 3, 4, 79.060000000000002 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 29, 6, 4, 30.440000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 11, 3, 1, 0.65000000000000002 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 10, 2, 6, 3.5299999999999998 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 9, 2, 5, 1.4399999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 8, 2, 4, 107.43000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 7, 2, 3, 1.3600000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 6, 2, 1, 0.89000000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 5, 1, 6, 3.9700000000000002 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 4, 1, 5, 1.6299999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 3, 1, 4, 120.89 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 2, 1, 3, 1.53 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 1, 1, 2, 1.1299999999999999 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 14, 3, 5, 1.0600000000000001 });

            migrationBuilder.InsertData(
                table: "CurrencyExchange",
                columns: new[] { "CurrencyExchangeId", "CurrencyId_From", "CurrencyId_To", "Equivalent" },
                values: new object[] { 30, 6, 5, 0.40999999999999998 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "CurrencyExchange");
        }
    }
}
