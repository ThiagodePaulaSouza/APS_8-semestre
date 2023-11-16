using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuscarReciclaveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Primeiroteste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaReciclavel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    TextoCategoria = table.Column<string>(type: "text", nullable: false),
                    CascadeMode = table.Column<int>(type: "integer", nullable: false),
                    ClassLevelCascadeMode = table.Column<int>(type: "integer", nullable: false),
                    RuleLevelCascadeMode = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAtualizado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaReciclavel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemReciclavel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextoItem = table.Column<string>(type: "text", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    CategoriaReciclavelId = table.Column<int>(type: "integer", nullable: false),
                    CascadeMode = table.Column<int>(type: "integer", nullable: false),
                    ClassLevelCascadeMode = table.Column<int>(type: "integer", nullable: false),
                    RuleLevelCascadeMode = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAtualizado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReciclavel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReciclavel_CategoriaReciclavel_CategoriaReciclavelId",
                        column: x => x.CategoriaReciclavelId,
                        principalTable: "CategoriaReciclavel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReciclavel_CategoriaReciclavelId",
                table: "ItemReciclavel",
                column: "CategoriaReciclavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemReciclavel");

            migrationBuilder.DropTable(
                name: "CategoriaReciclavel");
        }
    }
}
