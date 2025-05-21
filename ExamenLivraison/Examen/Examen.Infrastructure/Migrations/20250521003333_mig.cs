using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livreur",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RasseSociale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreur", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitesseLimite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.Matricule);
                });

            migrationBuilder.CreateTable(
                name: "Colis",
                columns: table => new
                {
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    LivreurFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    Poids = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colis", x => new { x.ClientFK, x.LivreurFK });
                    table.ForeignKey(
                        name: "FK_Colis_Client_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colis_Livreur_LivreurFK",
                        column: x => x.LivreurFK,
                        principalTable: "Livreur",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camions",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NbrEssieux = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camions", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Camions_Vehicule_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conduite",
                columns: table => new
                {
                    LivreursCIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehiculesMatricule = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conduite", x => new { x.LivreursCIN, x.VehiculesMatricule });
                    table.ForeignKey(
                        name: "FK_Conduite_Livreur_LivreursCIN",
                        column: x => x.LivreursCIN,
                        principalTable: "Livreur",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conduite_Vehicule_VehiculesMatricule",
                        column: x => x.VehiculesMatricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NbrPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Voitures_Vehicule_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colis_LivreurFK",
                table: "Colis",
                column: "LivreurFK");

            migrationBuilder.CreateIndex(
                name: "IX_Conduite_VehiculesMatricule",
                table: "Conduite",
                column: "VehiculesMatricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camions");

            migrationBuilder.DropTable(
                name: "Colis");

            migrationBuilder.DropTable(
                name: "Conduite");

            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Livreur");

            migrationBuilder.DropTable(
                name: "Vehicule");
        }
    }
}
