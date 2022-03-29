using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSystem.DL.Migrations
{
    public partial class InitializeEmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Sender = table.Column<string>(maxLength: 64, nullable: true),
                    Recipient = table.Column<string>(maxLength: 64, nullable: true),
                    Message = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
