using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI5.Migrations
{
    public partial class CriacaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Admin = table.Column<bool>(type: "INTEGER", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
