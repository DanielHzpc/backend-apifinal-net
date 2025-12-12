using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresa.Migrations
{
    /// <inheritdoc />
    public partial class CambioAEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserNombre",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserNombre");
        }
    }
}
