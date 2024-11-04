using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicably.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrandId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02e3bcbf-b759-4b79-a968-168ecc8e6897"), "Brand B" },
                    { new Guid("726d2d38-de1d-401f-b436-e4159ad01be3"), "Brand A" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("11570e99-46a3-45a4-adee-0fff0e0e9062"), new Guid("02e3bcbf-b759-4b79-a968-168ecc8e6897"), "Model B1" },
                    { new Guid("61452c03-91e9-47bc-a0bc-f7887c178023"), new Guid("726d2d38-de1d-401f-b436-e4159ad01be3"), "Model A3" },
                    { new Guid("70ab0cd7-6870-4540-8680-edc1e8330bce"), new Guid("02e3bcbf-b759-4b79-a968-168ecc8e6897"), "Model B2" },
                    { new Guid("81bd8ba8-3173-4a26-a4fe-73006ad46e37"), new Guid("02e3bcbf-b759-4b79-a968-168ecc8e6897"), "Model B3" },
                    { new Guid("a4560ea7-67c9-45f7-92c1-fbab6e6bf3f9"), new Guid("726d2d38-de1d-401f-b436-e4159ad01be3"), "Model A1" },
                    { new Guid("a5732caa-03ae-41a1-9d46-7f01e01186a1"), new Guid("726d2d38-de1d-401f-b436-e4159ad01be3"), "Model A2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_BrandId",
                table: "VehicleModels",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
