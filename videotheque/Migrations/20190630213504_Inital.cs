using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace videotheque.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Note = table.Column<int>(nullable: false),
                    AgeMinimum = table.Column<int>(nullable: false),
                    Titre = table.Column<string>(nullable: true),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Vu = table.Column<bool>(nullable: false),
                    SupportPhysique = table.Column<bool>(nullable: false),
                    SupportNumerique = table.Column<bool>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: false),
                    DateSortie = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Nationalite = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenre",
                columns: table => new
                {
                    IdGenre = table.Column<int>(nullable: false),
                    IdMedia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenre", x => new { x.IdGenre, x.IdMedia });
                    table.ForeignKey(
                        name: "FK_MediaGenre_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaPersonne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPersonne = table.Column<int>(nullable: false),
                    IdMedia = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPersonne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Personne_IdPersonne",
                        column: x => x.IdPersonne,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_IdMedia",
                table: "MediaGenre",
                column: "IdMedia");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonne_IdMedia",
                table: "MediaPersonne",
                column: "IdMedia");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonne_IdPersonne",
                table: "MediaPersonne",
                column: "IdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaGenre");

            migrationBuilder.DropTable(
                name: "MediaPersonne");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
