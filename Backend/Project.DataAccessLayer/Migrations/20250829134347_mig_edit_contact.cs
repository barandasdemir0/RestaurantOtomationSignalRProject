using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_edit_contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterOpenDayMonday",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FooterOpenFriday",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FooterOpenSaturday",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FooterOpenSpecialDay",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FooterOpenSunday",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "FooterOpenWednesday",
                table: "Contacts",
                newName: "OpenHours");

            migrationBuilder.RenameColumn(
                name: "FooterOpenTuesday",
                table: "Contacts",
                newName: "OpenDaysDescription");

            migrationBuilder.RenameColumn(
                name: "FooterOpenThursday",
                table: "Contacts",
                newName: "OpenDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenHours",
                table: "Contacts",
                newName: "FooterOpenWednesday");

            migrationBuilder.RenameColumn(
                name: "OpenDaysDescription",
                table: "Contacts",
                newName: "FooterOpenTuesday");

            migrationBuilder.RenameColumn(
                name: "OpenDays",
                table: "Contacts",
                newName: "FooterOpenThursday");

            migrationBuilder.AddColumn<string>(
                name: "FooterOpenDayMonday",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterOpenFriday",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterOpenSaturday",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterOpenSpecialDay",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterOpenSunday",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
