using Microsoft.EntityFrameworkCore.Migrations;

namespace AfriLearnBackend.Migrations
{
    public partial class AuthUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthKey",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthKey",
                table: "AspNetUsers");
        }
    }
}
