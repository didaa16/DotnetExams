using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ahmedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialiteId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    SpecialiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.SpecialiteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_SpecialiteId",
                table: "Participants",
                column: "SpecialiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Specialite_SpecialiteId",
                table: "Participants",
                column: "SpecialiteId",
                principalTable: "Specialite",
                principalColumn: "SpecialiteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Specialite_SpecialiteId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "Specialite");

            migrationBuilder.DropIndex(
                name: "IX_Participants_SpecialiteId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "SpecialiteId",
                table: "Participants");
        }
    }
}
