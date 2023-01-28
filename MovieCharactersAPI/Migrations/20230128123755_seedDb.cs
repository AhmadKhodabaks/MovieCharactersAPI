using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    public partial class seedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Character_CharactersCharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movie_MoviesMovieId",
                table: "CharacterMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "CharacterMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "CharactersCharacterId",
                table: "CharacterMovie",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MoviesMovieId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MovieId");

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "PictureURL" },
                values: new object[,]
                {
                    { 1, "None", "FullName1", 0, "Not Given" },
                    { 2, "None", "FullName2", 0, "Not Given" },
                    { 3, "None", "FullName3", 0, "Not Given" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description1", "Franchise1" },
                    { 2, "Description2", "Franchise2" },
                    { 3, "Description3", "Franchise3" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "PictureURL", "ReleaseYear", "Title", "TrailerURl" },
                values: new object[] { 1, "Director1", 1, "Genre3", "", "2001", "Title1", "" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "PictureURL", "ReleaseYear", "Title", "TrailerURl" },
                values: new object[] { 2, "Director2", 2, "Genre2", "", "2002", "Title2", "" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "PictureURL", "ReleaseYear", "Title", "TrailerURl" },
                values: new object[] { 3, "Director3", 3, "Genre3", "", "2003", "Title3", "" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Character_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movie_MovieId",
                table: "CharacterMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Character_CharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movie_MovieId",
                table: "CharacterMovie");

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "CharacterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "FranchiseId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "CharacterMovie",
                newName: "MoviesMovieId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterMovie",
                newName: "CharactersCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Character_CharactersCharacterId",
                table: "CharacterMovie",
                column: "CharactersCharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movie_MoviesMovieId",
                table: "CharacterMovie",
                column: "MoviesMovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
