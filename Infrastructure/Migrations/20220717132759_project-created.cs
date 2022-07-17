using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class projectcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ntr_projects",
                columns: table => new
                {
                    ntr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ntr_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ntr_style = table.Column<int>(type: "integer", nullable: false),
                    ntr_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ntr_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ntr_projects", x => x.ntr_id);
                });

            migrationBuilder.CreateTable(
                name: "ntr_project_notes",
                columns: table => new
                {
                    ntr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_note_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ntr_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ntr_project_notes", x => x.ntr_id);
                    table.ForeignKey(
                        name: "FK_ntr_project_notes_ntr_notes_ntr_note_id",
                        column: x => x.ntr_note_id,
                        principalTable: "ntr_notes",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ntr_project_notes_ntr_projects_ntr_project_id",
                        column: x => x.ntr_project_id,
                        principalTable: "ntr_projects",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ntr_project_users",
                columns: table => new
                {
                    ntr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_access_level = table.Column<int>(type: "integer", nullable: false),
                    ntr_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ntr_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ntr_project_users", x => x.ntr_id);
                    table.ForeignKey(
                        name: "FK_ntr_project_users_ntr_projects_ntr_project_id",
                        column: x => x.ntr_project_id,
                        principalTable: "ntr_projects",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ntr_project_users_ntr_users_ntr_user_id",
                        column: x => x.ntr_user_id,
                        principalTable: "ntr_users",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ntr_project_notes_ntr_note_id",
                table: "ntr_project_notes",
                column: "ntr_note_id");

            migrationBuilder.CreateIndex(
                name: "IX_ntr_project_notes_ntr_project_id",
                table: "ntr_project_notes",
                column: "ntr_project_id");

            migrationBuilder.CreateIndex(
                name: "IX_ntr_project_users_ntr_project_id",
                table: "ntr_project_users",
                column: "ntr_project_id");

            migrationBuilder.CreateIndex(
                name: "IX_ntr_project_users_ntr_user_id",
                table: "ntr_project_users",
                column: "ntr_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ntr_project_notes");

            migrationBuilder.DropTable(
                name: "ntr_project_users");

            migrationBuilder.DropTable(
                name: "ntr_projects");
        }
    }
}
