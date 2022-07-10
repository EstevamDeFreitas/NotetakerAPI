using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class usernotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ntr_notes_ntr_users_ntr_owner_id",
                table: "ntr_notes");

            migrationBuilder.DropIndex(
                name: "IX_ntr_notes_ntr_owner_id",
                table: "ntr_notes");

            migrationBuilder.DropColumn(
                name: "ntr_owner_id",
                table: "ntr_notes");

            migrationBuilder.CreateTable(
                name: "UserNotes",
                columns: table => new
                {
                    ntr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_note_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_access_level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotes", x => new { x.ntr_user_id, x.ntr_note_id });
                    table.ForeignKey(
                        name: "FK_UserNotes_ntr_notes_ntr_note_id",
                        column: x => x.ntr_note_id,
                        principalTable: "ntr_notes",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotes_ntr_users_ntr_user_id",
                        column: x => x.ntr_user_id,
                        principalTable: "ntr_users",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_ntr_note_id",
                table: "UserNotes",
                column: "ntr_note_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotes");

            migrationBuilder.AddColumn<Guid>(
                name: "ntr_owner_id",
                table: "ntr_notes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ntr_notes_ntr_owner_id",
                table: "ntr_notes",
                column: "ntr_owner_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ntr_notes_ntr_users_ntr_owner_id",
                table: "ntr_notes",
                column: "ntr_owner_id",
                principalTable: "ntr_users",
                principalColumn: "ntr_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
