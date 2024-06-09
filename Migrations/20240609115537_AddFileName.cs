using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionTypesCMS.Migrations
{
    /// <inheritdoc />
    public partial class AddFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "AuctionTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "AuctionTypes");
        }
    }
}
