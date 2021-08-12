using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BelinaHelpDesk.Data.Migrations
{
    public partial class DomainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "HelpDeskStatuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HelpDeskTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TicketRequesterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketGuid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpDeskTicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpDeskTicketId = table.Column<int>(type: "int", nullable: false),
                    TicketDetailDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskTicketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpDeskTicketDetails_HelpDeskTickets_HelpDeskTicketId",
                        column: x => x.HelpDeskTicketId,
                        principalTable: "HelpDeskTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskTicketDetails_HelpDeskTicketId",
                table: "HelpDeskTicketDetails",
                column: "HelpDeskTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpDeskStatuses");

            migrationBuilder.DropTable(
                name: "HelpDeskTicketDetails");

            migrationBuilder.DropTable(
                name: "HelpDeskTickets");

        }
    }
}
