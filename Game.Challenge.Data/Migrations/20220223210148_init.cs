using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Challenge.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    UserGameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameState = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.UserGameId);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "ThumbnailImage" },
                values: new object[] { 1L, "Call of duty", "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "ThumbnailImage" },
                values: new object[] { 2L, "Need for speed", "https://previews.123rf.com/images/aquir/aquir1311/aquir131100316/23569861-.jpg?fj=1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Username" },
                values: new object[] { 1L, "Test@gmail.com", "FirstName Test 1", "LastName Test 1", "UserNameTest" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "Country", "Line1", "Line2", "Line3", "UserId", "ZipCode" },
                values: new object[] { 1L, "Berlin", "Germany", "Line 1 of Address Test", "Line 2 of Address Test", "Line 3 of Address Test", 1L, "10700" });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "UserGameId", "GameId", "GameState", "LastPlayed", "RegisterDate", "UserId" },
                values: new object[] { 1L, 1L, 1, new DateTime(2022, 2, 23, 22, 1, 48, 346, DateTimeKind.Local).AddTicks(9549), new DateTime(2022, 2, 16, 22, 1, 48, 346, DateTimeKind.Local).AddTicks(9622), 1L });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "UserGameId", "GameId", "GameState", "LastPlayed", "RegisterDate", "UserId" },
                values: new object[] { 2L, 2L, 1, new DateTime(2022, 2, 21, 22, 1, 48, 346, DateTimeKind.Local).AddTicks(9655), new DateTime(2022, 2, 13, 22, 1, 48, 346, DateTimeKind.Local).AddTicks(9660), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
