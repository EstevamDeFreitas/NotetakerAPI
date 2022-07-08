using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class creationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ntr_user",
                columns: table => new
                {
                    ntr_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ntr_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ntr_password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ntr_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ntr_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ntr_user", x => x.ntr_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ntr_user");
        }
    }
}
