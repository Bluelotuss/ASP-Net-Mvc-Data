using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_Net_Mvc_Data.Migrations
{
    public partial class changedDbNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityList_CountryList_CountryId",
                table: "CityList");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageList_PersonList_PersonId",
                table: "LanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguageList_LanguageList_LanguageID",
                table: "PersonLanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguageList_PersonList_PersonID",
                table: "PersonLanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_CityList_CityId",
                table: "PersonList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguageList",
                table: "PersonLanguageList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageList",
                table: "LanguageList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryList",
                table: "CountryList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityList",
                table: "CityList");

            migrationBuilder.RenameTable(
                name: "PersonList",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "PersonLanguageList",
                newName: "PersonLanguage");

            migrationBuilder.RenameTable(
                name: "LanguageList",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "CountryList",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "CityList",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_PersonList_CityId",
                table: "People",
                newName: "IX_People_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguageList_PersonID",
                table: "PersonLanguage",
                newName: "IX_PersonLanguage_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguageList_LanguageID",
                table: "PersonLanguage",
                newName: "IX_PersonLanguage_LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageList_PersonId",
                table: "Language",
                newName: "IX_Language_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CityList_CountryId",
                table: "City",
                newName: "IX_City_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Language_People_PersonId",
                table: "Language",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityId",
                table: "People",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Language_LanguageID",
                table: "PersonLanguage",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_People_PersonID",
                table: "PersonLanguage",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_People_PersonId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Language_LanguageID",
                table: "PersonLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_People_PersonID",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "PersonLanguage",
                newName: "PersonLanguageList");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "PersonList");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "LanguageList");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "CountryList");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "CityList");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguage_PersonID",
                table: "PersonLanguageList",
                newName: "IX_PersonLanguageList_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguage_LanguageID",
                table: "PersonLanguageList",
                newName: "IX_PersonLanguageList_LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_People_CityId",
                table: "PersonList",
                newName: "IX_PersonList_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Language_PersonId",
                table: "LanguageList",
                newName: "IX_LanguageList_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryId",
                table: "CityList",
                newName: "IX_CityList_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguageList",
                table: "PersonLanguageList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageList",
                table: "LanguageList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryList",
                table: "CountryList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityList",
                table: "CityList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityList_CountryList_CountryId",
                table: "CityList",
                column: "CountryId",
                principalTable: "CountryList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageList_PersonList_PersonId",
                table: "LanguageList",
                column: "PersonId",
                principalTable: "PersonList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguageList_LanguageList_LanguageID",
                table: "PersonLanguageList",
                column: "LanguageID",
                principalTable: "LanguageList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguageList_PersonList_PersonID",
                table: "PersonLanguageList",
                column: "PersonID",
                principalTable: "PersonList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonList_CityList_CityId",
                table: "PersonList",
                column: "CityId",
                principalTable: "CityList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
