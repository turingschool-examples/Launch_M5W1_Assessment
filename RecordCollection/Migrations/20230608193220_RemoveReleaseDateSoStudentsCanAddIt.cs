using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordCollection.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReleaseDateSoStudentsCanAddIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "release_date",
                table: "albums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "release_date",
                table: "albums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
