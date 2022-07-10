using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class usernotetoentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes");

            migrationBuilder.AddColumn<Guid>(
                name: "ntr_id",
                table: "ntr_user_notes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ntr_dt_creation",
                table: "ntr_user_notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ntr_dt_modified",
                table: "ntr_user_notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes",
                column: "ntr_id");

            migrationBuilder.CreateIndex(
                name: "IX_ntr_user_notes_ntr_user_id",
                table: "ntr_user_notes",
                column: "ntr_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes");

            migrationBuilder.DropIndex(
                name: "IX_ntr_user_notes_ntr_user_id",
                table: "ntr_user_notes");

            migrationBuilder.DropColumn(
                name: "ntr_id",
                table: "ntr_user_notes");

            migrationBuilder.DropColumn(
                name: "ntr_dt_creation",
                table: "ntr_user_notes");

            migrationBuilder.DropColumn(
                name: "ntr_dt_modified",
                table: "ntr_user_notes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ntr_user_notes",
                table: "ntr_user_notes",
                column: "ntr_user_id");
        }
    }
}
