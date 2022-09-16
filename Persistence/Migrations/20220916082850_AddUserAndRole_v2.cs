using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddUserAndRole_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Roles_RoleId",
                table: "DbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSet",
                table: "DbSet");

            migrationBuilder.RenameTable(
                name: "DbSet",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_DbSet_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "DbSet");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "DbSet",
                newName: "IX_DbSet_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSet",
                table: "DbSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Roles_RoleId",
                table: "DbSet",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
