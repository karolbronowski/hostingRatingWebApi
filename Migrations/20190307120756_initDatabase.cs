using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace hostingRatingWebApi.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandPackages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountCapacity = table.Column<string>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false),
                    Databases = table.Column<string>(nullable: true),
                    Domains = table.Column<string>(nullable: true),
                    EmailAccount = table.Column<string>(nullable: true),
                    FtpAccounts = table.Column<string>(nullable: true),
                    MonthlyTransfer = table.Column<string>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    PriceForNextYear = table.Column<decimal>(nullable: false),
                    PriceForYear = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandPackages_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BrandPackageId = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_BrandPackages_BrandPackageId",
                        column: x => x.BrandPackageId,
                        principalTable: "BrandPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandPackages_BrandId",
                table: "BrandPackages",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatorId",
                table: "Brands",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_BrandPackageId",
                table: "Rate",
                column: "BrandPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_UserId",
                table: "Rate",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "BrandPackages");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
