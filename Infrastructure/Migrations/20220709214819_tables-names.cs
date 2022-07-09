using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class tablesnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_ntr_user_ntr_owner_id",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_user",
                table: "ntr_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "ntr_user",
                newName: "ntr_users");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "ntr_notes");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ntr_owner_id",
                table: "ntr_notes",
                newName: "IX_ntr_notes_ntr_owner_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_users",
                table: "ntr_users",
                column: "ntr_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_notes",
                table: "ntr_notes",
                column: "ntr_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ntr_notes_ntr_users_ntr_owner_id",
                table: "ntr_notes",
                column: "ntr_owner_id",
                principalTable: "ntr_users",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ntr_notes_ntr_users_ntr_owner_id",
                table: "ntr_notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_users",
                table: "ntr_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_notes",
                table: "ntr_notes");

            migrationBuilder.RenameTable(
                name: "ntr_users",
                newName: "ntr_user");

            migrationBuilder.RenameTable(
                name: "ntr_notes",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_ntr_notes_ntr_owner_id",
                table: "Notes",
                newName: "IX_Notes_ntr_owner_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_user",
                table: "ntr_user",
                column: "ntr_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "ntr_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_ntr_user_ntr_owner_id",
                table: "Notes",
                column: "ntr_owner_id",
                principalTable: "ntr_user",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
