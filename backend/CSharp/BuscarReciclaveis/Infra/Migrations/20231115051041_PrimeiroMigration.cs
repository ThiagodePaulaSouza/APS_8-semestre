using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuscarReciclaveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiroMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasReciclaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextoCategoria = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAtualizado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasReciclaveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsReciclaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextoItem = table.Column<string>(type: "text", nullable: false),
                    IdCategoriasReciclaveis = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAtualizado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsReciclaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsReciclaveis_CategoriasReciclaveis_IdCategoriasReciclav~",
                        column: x => x.IdCategoriasReciclaveis,
                        principalTable: "CategoriasReciclaveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsReciclaveis_IdCategoriasReciclaveis",
                table: "ItemsReciclaveis",
                column: "IdCategoriasReciclaveis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsReciclaveis");

            migrationBuilder.DropTable(
                name: "CategoriasReciclaveis");
        }
    }
}
