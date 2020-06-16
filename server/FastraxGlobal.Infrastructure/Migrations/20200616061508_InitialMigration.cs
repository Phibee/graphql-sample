using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastraxGlobal.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "settings");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 32, nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(250)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DesignationId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "settings",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "settings",
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "settings",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "settings",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "settings",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "settings",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                schema: "settings",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DesignationId",
                schema: "settings",
                table: "Users",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Username",
                schema: "settings",
                table: "Users",
                columns: new[] { "Email", "Username" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "settings");

            migrationBuilder.DropTable(
                name: "Designations",
                schema: "settings");
        }
    }
}
