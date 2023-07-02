using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class addstripeidtofreelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripeAccountId",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeAccountId",
                table: "Freelancers");
        }
    }
}
