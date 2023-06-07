using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComSysSoftw_Backend.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addIsVetColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVet",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVet",
                table: "Users");
        }
    }
}
