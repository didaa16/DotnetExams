using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FeteAhmedMezni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    IdInvite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresseInvite = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.IdInvite);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    IdSalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AdresseSalle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    PrixParHeure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.IdSalle);
                });

            migrationBuilder.CreateTable(
                name: "Fete",
                columns: table => new
                {
                    IdFete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NbInvitesMax = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    DateFete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalleIdSalle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fete", x => x.IdFete);
                    table.ForeignKey(
                        name: "FK_Fete_Salle_SalleIdSalle",
                        column: x => x.SalleIdSalle,
                        principalTable: "Salle",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    DateInvitation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeteFK = table.Column<int>(type: "int", nullable: false),
                    InviteFK = table.Column<int>(type: "int", nullable: false),
                    ConfirmerInvitation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => new { x.FeteFK, x.InviteFK, x.DateInvitation });
                    table.ForeignKey(
                        name: "FK_Invitations_Fete_FeteFK",
                        column: x => x.FeteFK,
                        principalTable: "Fete",
                        principalColumn: "IdFete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitations_Invite_InviteFK",
                        column: x => x.InviteFK,
                        principalTable: "Invite",
                        principalColumn: "IdInvite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fete_SalleIdSalle",
                table: "Fete",
                column: "SalleIdSalle");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InviteFK",
                table: "Invitations",
                column: "InviteFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "Fete");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Salle");
        }
    }
}
