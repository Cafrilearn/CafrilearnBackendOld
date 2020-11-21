using Microsoft.EntityFrameworkCore.Migrations;

namespace AfriLearnBackend.Migrations
{
    public partial class UpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignedIn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudyLevel",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TermsAndConditionsChecked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institution",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSignedIn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudyLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsChecked",
                table: "AspNetUsers");
        }
    }
}
