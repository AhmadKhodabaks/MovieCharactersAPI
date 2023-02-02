using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.FranchiseId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "PictureURL" },
                values: new object[,]
                {
                    { 1, "None", "FullName1", "Male", "Not Given" },
                    { 2, "None", "FullName2", "Male", "Not Given" },
                    { 3, "None", "FullName3", "Female", "Not Given" }
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
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
