using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mezni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membre",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projetCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprint_Projet_projetCode",
                        column: x => x.projetCode,
                        principalTable: "Projet",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SprintKey = table.Column<int>(type: "int", nullable: false),
                    MembreKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => new { x.SprintKey, x.MembreKey, x.Titre });
                    table.ForeignKey(
                        name: "FK_Taches_Membre_MembreKey",
                        column: x => x.MembreKey,
                        principalTable: "Membre",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taches_Sprint_SprintKey",
                        column: x => x.SprintKey,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_projetCode",
                table: "Sprint",
                column: "projetCode");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_MembreKey",
                table: "Taches",
                column: "MembreKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Projet");
        }
    }
}
