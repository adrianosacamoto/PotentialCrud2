using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DesenvolvedorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(nullable: true),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Hobby = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedor");
        }
    }
}
