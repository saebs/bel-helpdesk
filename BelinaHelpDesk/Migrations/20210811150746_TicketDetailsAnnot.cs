using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BelinaHelpDesk.Migrations
{
    public partial class TicketDetailsAnnot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpDeskTicketDetails_HelpDeskTickets_HelpDeskTicketId",
                table: "HelpDeskTicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_HelpDeskTicketDetails_HelpDeskTicketId",
                table: "HelpDeskTicketDetails");

            migrationBuilder.RenameColumn(
                name: "TicketGuid",
                table: "HelpDeskTickets",
                newName: "TicketGUID");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "TicketStatus",
                table: "HelpDeskTickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TicketRequesterEmail",
                table: "HelpDeskTickets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketGUID",
                table: "HelpDeskTickets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "HelpDeskTickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TicketDate",
                table: "HelpDeskTickets",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TicketDetailDate",
                table: "HelpDeskTicketDetails",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "HelpDeskTicketDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketGUID",
                table: "HelpDeskTickets",
                newName: "TicketGuid");

            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "TicketStatus",
                table: "HelpDeskTickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TicketRequesterEmail",
                table: "HelpDeskTickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TicketGuid",
                table: "HelpDeskTickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "HelpDeskTickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TicketDate",
                table: "HelpDeskTickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TicketDetailDate",
                table: "HelpDeskTicketDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "TicketDescription",
                table: "HelpDeskTicketDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskTicketDetails_HelpDeskTicketId",
                table: "HelpDeskTicketDetails",
                column: "HelpDeskTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpDeskTicketDetails_HelpDeskTickets_HelpDeskTicketId",
                table: "HelpDeskTicketDetails",
                column: "HelpDeskTicketId",
                principalTable: "HelpDeskTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
