using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BelinaHelpDesk.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false,  maxLength:450 , type:"nvarchar(450)"),
                    Name = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    ConcurrencyStamp = table.Column<string>(nullable: true, type:"nvarchar(max)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, type:"nvarchar(450)"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    Email = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true, type:"nvarchar(256)"),
                    EmailConfirmed = table.Column<bool>(nullable: false, type:"bit"),
                    PasswordHash = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    SecurityStamp = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    ConcurrencyStamp = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    PhoneNumber = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, type:"bit"),
                    TwoFactorEnabled = table.Column<bool>(nullable: false, type:"bit"),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true, type:"nvarchar(max)"),
                    LockoutEnabled = table.Column<bool>(nullable: false, type:"bit"),
                    AccessFailedCount = table.Column<int>(nullable: false, type:"int")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, type:"bigint")
                        .Annotation("SqlServer:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false, type:"nvarchar(450)"),
                    ClaimType = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    ClaimValue = table.Column<string>(nullable: true, type:"nvarchar(max)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, type:"bigint")
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false, type:"nvarchar(450)"),
                    ClaimType = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    ClaimValue = table.Column<string>(nullable: true, type:"nvarchar(max)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false, type:"nvarchar(128)"),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false, type:"nvarchar(128)"),
                    ProviderDisplayName = table.Column<string>(nullable: true, type:"nvarchar(max)"),
                    UserId = table.Column<string>(nullable: false, type:"nvarchar(450)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false, type:"nvarchar(450)"),
                    RoleId = table.Column<string>(nullable: false, type:"nvarchar(450)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false, type:"nvarchar(450)"),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false, type:"nvarchar(128)"),
                    Name = table.Column<string>(maxLength: 128, nullable: false, type:"nvarchar(128)"),
                    Value = table.Column<string>(nullable: true, type:"nvarchar(max)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
