using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arnold_Web_API.Migrations
{
    public partial class AddWorkoutAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workout_audit",
                columns: table => new
                {
                    audit_id = table.Column<int>(type: "int(11)", nullable: false),
                    made_by = table.Column<int>(type: "int(11)", nullable: false),
                    modified_by = table.Column<int>(type: "int(11)", nullable: false),
                    action_type = table.Column<string>(type: "varchar(50)", nullable: false),
                    made_at = table.Column<DateTime>(type: "DateTime", nullable: false),
                    modified_at = table.Column<DateTime>(type: "Datetime", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new {x.audit_id})
                        .Annotation("MySql:IndexPrefixLength", new[] {0, 0});
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
