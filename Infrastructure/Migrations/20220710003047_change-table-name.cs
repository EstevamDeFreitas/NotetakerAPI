using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class changetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotes_ntr_notes_ntr_note_id",
                table: "UserNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotes_ntr_users_ntr_user_id",
                table: "UserNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotes",
                table: "UserNotes");

            migrationBuilder.RenameTable(
                name: "UserNotes",
                newName: "ntr_user_notes");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotes_ntr_note_id",
                table: "ntr_user_notes",
                newName: "IX_ntr_user_notes_ntr_note_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes",
                column: "ntr_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ntr_user_notes_ntr_notes_ntr_note_id",
                table: "ntr_user_notes",
                column: "ntr_note_id",
                principalTable: "ntr_notes",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ntr_user_notes_ntr_users_ntr_user_id",
                table: "ntr_user_notes",
                column: "ntr_user_id",
                principalTable: "ntr_users",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ntr_user_notes_ntr_notes_ntr_note_id",
                table: "ntr_user_notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ntr_user_notes_ntr_users_ntr_user_id",
                table: "ntr_user_notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes");

            migrationBuilder.RenameTable(
                name: "ntr_user_notes",
                newName: "UserNotes");

            migrationBuilder.RenameIndex(
                name: "IX_ntr_user_notes_ntr_note_id",
                table: "UserNotes",
                newName: "IX_UserNotes_ntr_note_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotes",
                table: "UserNotes",
                column: "ntr_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotes_ntr_notes_ntr_note_id",
                table: "UserNotes",
                column: "ntr_note_id",
                principalTable: "ntr_notes",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotes_ntr_users_ntr_user_id",
                table: "UserNotes",
                column: "ntr_user_id",
                principalTable: "ntr_users",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
