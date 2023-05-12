using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class EnhancementApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "Payment_typeId",
                table: "Services");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Services",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "Freelancers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Freelancers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ApplicationUserId1",
                table: "Freelancers",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_AspNetUsers_ApplicationUserId1",
                table: "Freelancers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_AspNetUsers_ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Clients");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Services",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Payment_typeId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
