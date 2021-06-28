using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(name: "Pelicula Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechadeEstreno = table.Column<DateTime>(name: "Fecha de Estreno", type: "datetime2", nullable: false),
                    Caificacion = table.Column<int>(type: "int", nullable: false),
                    PersonajeId = table.Column<int>(name: "Personaje Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(name: "Personaje Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PeliculaId = table.Column<int>(name: "Pelicula Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.PersonajeId);
                    table.ForeignKey(
                        name: "FK_Characters_Movies_Pelicula Id",
                        column: x => x.PeliculaId,
                        principalTable: "Movies",
                        principalColumn: "Pelicula Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GeneroId = table.Column<int>(name: "Genero Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeliculaId = table.Column<int>(name: "Pelicula Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GeneroId);
                    table.ForeignKey(
                        name: "FK_Genres_Movies_Pelicula Id",
                        column: x => x.PeliculaId,
                        principalTable: "Movies",
                        principalColumn: "Pelicula Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Pelicula Id",
                table: "Characters",
                column: "Pelicula Id");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Pelicula Id",
                table: "Genres",
                column: "Pelicula Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Personaje Id",
                table: "Movies",
                column: "Personaje Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Characters_Personaje Id",
                table: "Movies",
                column: "Personaje Id",
                principalTable: "Characters",
                principalColumn: "Personaje Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Movies_Pelicula Id",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
