using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class RemoveVerificationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_Verifications_VerificationId1",
                table: "Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Verifications_VerificationId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropIndex(
                name: "IX_Services_VerificationId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_VerificationId1",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "VerificationId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "VerificationId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "VerificationId1",
                table: "Freelancers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerificationId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerificationId",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerificationId1",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    BackImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrontImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verifications_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_VerificationId",
                table: "Services",
                column: "VerificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_VerificationId1",
                table: "Freelancers",
                column: "VerificationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Verifications_FreelancerId",
                table: "Verifications",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_Verifications_VerificationId1",
                table: "Freelancers",
                column: "VerificationId1",
                principalTable: "Verifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Verifications_VerificationId",
                table: "Services",
                column: "VerificationId",
                principalTable: "Verifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
