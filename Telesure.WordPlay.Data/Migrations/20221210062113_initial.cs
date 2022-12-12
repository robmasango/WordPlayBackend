using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Telesure.WordPlay.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Phrase = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    WordTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordTypes_WordTypeId",
                        column: x => x.WordTypeId,
                        principalTable: "WordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WordTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Noun" },
                    { 2, null, "Verb" },
                    { 3, null, "Adjective" },
                    { 4, null, "Adverb" },
                    { 5, null, "Pronoun" },
                    { 6, null, "Preposition" },
                    { 7, null, "Conjunction" },
                    { 8, null, "Determiner" },
                    { 9, null, "Exclamation" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Name", "WordTypeId" },
                values: new object[] { 1, "He", 5 });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Name", "WordTypeId" },
                values: new object[] { 2, "Grudgingly", 4 });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Name", "WordTypeId" },
                values: new object[] { 3, "1Life", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordTypeId",
                table: "Words",
                column: "WordTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordTypes");
        }
    }
}
