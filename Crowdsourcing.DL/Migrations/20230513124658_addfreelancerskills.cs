using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class addfreelancerskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherSkills_Skills_SkillId",
                table: "OtherSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Skills_SkillId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "HasFreelancerServices");

            migrationBuilder.DropTable(
                name: "HasSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Services_SkillId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_OtherSkills_SkillId",
                table: "OtherSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "OtherSkills");

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "FreelancerServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerServices_FreelancerId",
                table: "FreelancerServices",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_FreelancerId",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FreelancerServices_Freelancers_FreelancerId",
                table: "FreelancerServices",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreelancerServices_Freelancers_FreelancerId",
                table: "FreelancerServices");

            migrationBuilder.DropTable(
                name: "FreelancerSkills");

            migrationBuilder.DropIndex(
                name: "IX_FreelancerServices_FreelancerId",
                table: "FreelancerServices");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "FreelancerServices");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "OtherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HasFreelancerServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    FreelancerServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasFreelancerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasFreelancerServices_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasFreelancerServices_FreelancerServices_FreelancerServiceId",
                        column: x => x.FreelancerServiceId,
                        principalTable: "FreelancerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HasSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_SkillId",
                table: "Services",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherSkills_SkillId",
                table: "OtherSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_HasFreelancerServices_FreelancerId",
                table: "HasFreelancerServices",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_HasFreelancerServices_FreelancerServiceId",
                table: "HasFreelancerServices",
                column: "FreelancerServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSkills_FreelancerId",
                table: "HasSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSkills_SkillId",
                table: "HasSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherSkills_Skills_SkillId",
                table: "OtherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Skills_SkillId",
                table: "Services",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
