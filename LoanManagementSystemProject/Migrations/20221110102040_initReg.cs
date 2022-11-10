using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementSystemProject.Migrations
{
    public partial class initReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminModel",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModel", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "LoanModels",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    MaxTenure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanModels", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LoanMasters",
                columns: table => new
                {
                    LoanNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<int>(type: "int", nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfApproval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanMasters", x => x.LoanNumber);
                    table.ForeignKey(
                        name: "FK_LoanMasters_AdminModel_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AdminModel",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanMasters_LoanModels_LoanId",
                        column: x => x.LoanId,
                        principalTable: "LoanModels",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanMasters_UserModel_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "UserModel",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminModel_EmailAddress",
                table: "AdminModel",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanMasters_AdminId",
                table: "LoanMasters",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMasters_CustomerId",
                table: "LoanMasters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanMasters_LoanId",
                table: "LoanMasters",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_EmailAddress",
                table: "UserModel",
                column: "EmailAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanMasters");

            migrationBuilder.DropTable(
                name: "AdminModel");

            migrationBuilder.DropTable(
                name: "LoanModels");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
