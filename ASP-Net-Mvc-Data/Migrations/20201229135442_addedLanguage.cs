using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ASP_Net_Mvc_Data.Migrations
{
    public partial class addedLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageTitle = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageList_PersonList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguageList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonID = table.Column<int>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLanguageList_LanguageList_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguageList_PersonList_PersonID",
                        column: x => x.PersonID,
                        principalTable: "PersonList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageList_PersonId",
                table: "LanguageList",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguageList_LanguageID",
                table: "PersonLanguageList",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguageList_PersonID",
                table: "PersonLanguageList",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguageList");

            migrationBuilder.DropTable(
                name: "LanguageList");
        }
    }
}
