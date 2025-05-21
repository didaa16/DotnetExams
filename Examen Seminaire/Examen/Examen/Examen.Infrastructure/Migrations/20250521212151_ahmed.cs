using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ahmed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTelephone = table.Column<int>(type: "int", nullable: false),
                    TypeParticipant = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fonction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomEntreprise = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Niveau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomInstitut = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seminaire",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tarif = table.Column<double>(type: "float", nullable: false),
                    DateSeminaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreMaximal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminaire", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeminaireFK = table.Column<int>(type: "int", nullable: false),
                    ParticipantFK = table.Column<int>(type: "int", nullable: false),
                    TauxReduction = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => new { x.SeminaireFK, x.ParticipantFK, x.DateInscription });
                    table.ForeignKey(
                        name: "FK_Inscription_Participants_ParticipantFK",
                        column: x => x.ParticipantFK,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscription_Seminaire_SeminaireFK",
                        column: x => x.SeminaireFK,
                        principalTable: "Seminaire",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_ParticipantFK",
                table: "Inscription",
                column: "ParticipantFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Seminaire");
        }
    }
}
