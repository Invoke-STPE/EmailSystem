using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSystem.DL.Migrations
{
    public partial class AddSubjectEmailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Emails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Emails");
        }
    }
}
