using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Persistence.Migrations
{
    public partial class ResponseToFormDefinitionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Responses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_FormId",
                table: "Responses",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Forms_FormId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_FormId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Responses");
        }
    }
}
