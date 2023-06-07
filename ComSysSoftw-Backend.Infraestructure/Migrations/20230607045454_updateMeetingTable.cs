using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComSysSoftw_Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class updateMeetingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Users_UserId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Veterinaries_VeterinaryId",
                table: "Meeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_VeterinaryId",
                table: "Meetings",
                newName: "IX_Meetings_VeterinaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_UserId",
                table: "Meetings",
                newName: "IX_Meetings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_UserId",
                table: "Meetings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Veterinaries_VeterinaryId",
                table: "Meetings",
                column: "VeterinaryId",
                principalTable: "Veterinaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_UserId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Veterinaries_VeterinaryId",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_VeterinaryId",
                table: "Meeting",
                newName: "IX_Meeting_VeterinaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_UserId",
                table: "Meeting",
                newName: "IX_Meeting_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Users_UserId",
                table: "Meeting",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Veterinaries_VeterinaryId",
                table: "Meeting",
                column: "VeterinaryId",
                principalTable: "Veterinaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
