using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExamAct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activite",
                columns: table => new
                {
                    ActiviteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone_Ville = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Zone_Pays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    TypeService = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activite", x => x.ActiviteId);
                });

            migrationBuilder.CreateTable(
                name: "Conseiller",
                columns: table => new
                {
                    ConseillerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conseiller", x => x.ConseillerId);
                });

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    IntitulePack = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ConseillerFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Client_Conseiller_ConseillerFK",
                        column: x => x.ConseillerFK,
                        principalTable: "Conseiller",
                        principalColumn: "ConseillerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitePack",
                columns: table => new
                {
                    ActivitesActiviteId = table.Column<int>(type: "int", nullable: false),
                    PacksPackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitePack", x => new { x.ActivitesActiviteId, x.PacksPackId });
                    table.ForeignKey(
                        name: "FK_ActivitePack_Activite_ActivitesActiviteId",
                        column: x => x.ActivitesActiviteId,
                        principalTable: "Activite",
                        principalColumn: "ActiviteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitePack_Pack_PacksPackId",
                        column: x => x.PacksPackId,
                        principalTable: "Pack",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    PackFK = table.Column<int>(type: "int", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NbPersonnes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.ClientFK, x.PackFK });
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Client",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Pack_PackFK",
                        column: x => x.PackFK,
                        principalTable: "Pack",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitePack_PacksPackId",
                table: "ActivitePack",
                column: "PacksPackId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ConseillerFK",
                table: "Client",
                column: "ConseillerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PackFK",
                table: "Reservation",
                column: "PackFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitePack");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Activite");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropTable(
                name: "Conseiller");
        }
    }
}
