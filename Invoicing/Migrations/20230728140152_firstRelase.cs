using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoicing.Migrations
{
    /// <inheritdoc />
    public partial class firstRelase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoceDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lp = table.Column<int>(type: "int", nullable: false),
                    Name_product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP_Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price_netto = table.Column<double>(type: "float", nullable: false),
                    Price_Brutto = table.Column<double>(type: "float", nullable: false),
                    Tax_Vat = table.Column<double>(type: "float", nullable: false),
                    Vat = table.Column<int>(type: "int", nullable: false),
                    InvoceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTimeCreateInvoce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimePayInvoce = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoceDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "invoces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameConsument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP_Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price_netto = table.Column<double>(type: "float", nullable: false),
                    Price_Brutto = table.Column<double>(type: "float", nullable: false),
                    Tax_Vat = table.Column<double>(type: "float", nullable: false),
                    Vat = table.Column<int>(type: "int", nullable: false),
                    InvoceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTimeCreateInvoce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTimePayInvoce = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoce_created_Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoce_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_NIP",
                table: "customers",
                column: "NIP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sellers_NIP",
                table: "sellers",
                column: "NIP",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "invoceDBs");

            migrationBuilder.DropTable(
                name: "invoces");

            migrationBuilder.DropTable(
                name: "sellers");
        }
    }
}
