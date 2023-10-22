using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBaltaIO.Migrations.IbgeDb
{
    /// <inheritdoc />
    public partial class intialIBGE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    CadastradoPor = table.Column<Guid>(type: "TEXT", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    DataCadastro = table.Column<DateTime>(type: "INTEGER", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    EditadoPor = table.Column<Guid>(type: "TEXT", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    DataEdicao = table.Column<DateTime>(type: "INTEGER", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
