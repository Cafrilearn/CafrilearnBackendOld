using Microsoft.EntityFrameworkCore.Migrations;

namespace AfriLearnBackend.Migrations
{
    public partial class RMMarketing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarkettingNotificationsOn",
                table: "Setting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMarkettingNotificationsOn",
                table: "Setting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
