using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class notecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ntr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ntr_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ntr_owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_style = table.Column<int>(type: "integer", nullable: false),
                    ntr_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ntr_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ntr_id);
                    table.ForeignKey(
                        name: "FK_Notes_ntr_user_ntr_owner_id",
                        column: x => x.ntr_owner_id,
                        principalTable: "ntr_user",
                        principalColumn: "ntr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ntr_owner_id",
                table: "Notes",
                column: "ntr_owner_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
