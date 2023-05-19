using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class addEnumForStatusProposalEntityAndDeleteProposalStatusCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ProposalStatusCatalogs_ProposalStatusCatalogId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_ProposalStatusCatalogs_ProposalStatusCatalogId",
                table: "Proposals");

            migrationBuilder.DropTable(
                name: "ProposalStatusCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_ProposalStatusCatalogId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ProposalStatusCatalogId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ProposalStatusCatalogId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ProposalStatusCatalogId",
                table: "Proposals",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Proposals",
                newName: "ProposalStatusCatalogId");

            migrationBuilder.AddColumn<int>(
                name: "ProposalStatusCatalogId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProposalStatusCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalStatusCatalogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProposalStatusCatalogId",
                table: "Proposals",
                column: "ProposalStatusCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProposalStatusCatalogId",
                table: "Messages",
                column: "ProposalStatusCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ProposalStatusCatalogs_ProposalStatusCatalogId",
                table: "Messages",
                column: "ProposalStatusCatalogId",
                principalTable: "ProposalStatusCatalogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_ProposalStatusCatalogs_ProposalStatusCatalogId",
                table: "Proposals",
                column: "ProposalStatusCatalogId",
                principalTable: "ProposalStatusCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
