using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.Migrations
{
    public partial class DBsetTableChangeNameToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieRelations_DbSet_MovieId",
                table: "ActorMovieRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Producers_ProducerId",
                table: "DbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSet",
                table: "DbSet");

            migrationBuilder.RenameTable(
                name: "DbSet",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_DbSet_ProducerId",
                table: "Movie",
                newName: "IX_Movie_ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieRelations_Movie_MovieId",
                table: "ActorMovieRelations",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Producers_ProducerId",
                table: "Movie",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieRelations_Movie_MovieId",
                table: "ActorMovieRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Producers_ProducerId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "DbSet");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_ProducerId",
                table: "DbSet",
                newName: "IX_DbSet_ProducerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSet",
                table: "DbSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieRelations_DbSet_MovieId",
                table: "ActorMovieRelations",
                column: "MovieId",
                principalTable: "DbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Producers_ProducerId",
                table: "DbSet",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
