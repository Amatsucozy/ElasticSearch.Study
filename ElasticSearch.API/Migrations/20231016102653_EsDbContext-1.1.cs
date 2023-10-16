using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElasticSearch.API.Migrations
{
    /// <inheritdoc />
    public partial class EsDbContext11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "es",
                table: "ContactExtensionFields",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ContactExtensionFields_Id_Name",
                schema: "es",
                table: "ContactExtensionFields",
                columns: new[] { "Id", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactExtensionFields_Id_Name",
                schema: "es",
                table: "ContactExtensionFields");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "es",
                table: "ContactExtensionFields",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
