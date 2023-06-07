using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComSysSoftw_Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addPetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Veterinaries_VeterinaryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VeterinaryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VeterinaryId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Veterinaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinaries_UserId",
                table: "Veterinaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinaries_Users_UserId",
                table: "Veterinaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veterinaries_Users_UserId",
                table: "Veterinaries");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Veterinaries_UserId",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Veterinaries");

            migrationBuilder.AddColumn<int>(
                name: "VeterinaryId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VeterinaryId",
                table: "Users",
                column: "VeterinaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Veterinaries_VeterinaryId",
                table: "Users",
                column: "VeterinaryId",
                principalTable: "Veterinaries",
                principalColumn: "Id");
        }
    }
}
