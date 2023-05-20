using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class AddCategorySubAndLevelInFreelancerService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FreelancerServices",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "FreelancerServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "FreelancerServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "FreelancerServices");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "FreelancerServices");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "FreelancerServices",
                newName: "Name");
        }
    }
}
