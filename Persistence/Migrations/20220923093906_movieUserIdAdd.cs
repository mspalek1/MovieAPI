using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class movieUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CreatedById",
                table: "Movie",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Users_CreatedById",
                table: "Movie",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Users_CreatedById",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CreatedById",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Movie");
        }
    }
}
