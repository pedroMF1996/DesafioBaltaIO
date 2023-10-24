using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBaltaIO.Migrations
{
    /// <inheritdoc />
    public partial class remapearColunaCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EditadoPor",
                table: "Localidades",
                type: "nvarchar(36)",
                nullable: true,
                defaultValue: "00000000-0000-0000-0000-000000000000",
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true,
                oldDefaultValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Localidades",
                type: "nvarchar(160)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<string>(
                name: "CadastradoPor",
                table: "Localidades",
                type: "nvarchar(36)",
                nullable: true,
                defaultValue: "00000000-0000-0000-0000-000000000000",
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true,
                oldDefaultValue: "00000000-0000-0000-0000-000000000000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EditadoPor",
                table: "Localidades",
                type: "nvarchar",
                nullable: true,
                defaultValue: "00000000-0000-0000-0000-000000000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldNullable: true,
                oldDefaultValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Localidades",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(160)");

            migrationBuilder.AlterColumn<string>(
                name: "CadastradoPor",
                table: "Localidades",
                type: "nvarchar",
                nullable: true,
                defaultValue: "00000000-0000-0000-0000-000000000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldNullable: true,
                oldDefaultValue: "00000000-0000-0000-0000-000000000000");
        }
    }
}
