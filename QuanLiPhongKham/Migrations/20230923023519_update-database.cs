using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiPhongKham.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_NumberId",
                table: "ProvideNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_NumberId",
                table: "BHYTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_NumberId",
                table: "ProvideNumbers");

            migrationBuilder.DropColumn(
                name: "_NumberId",
                table: "BHYTS");
        }
    }
}
