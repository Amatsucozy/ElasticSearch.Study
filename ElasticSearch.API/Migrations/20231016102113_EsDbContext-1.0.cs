using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElasticSearch.API.Migrations
{
    /// <inheritdoc />
    public partial class EsDbContext10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "es");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "es",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactExtensionFields",
                schema: "es",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactExtensionFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactExtensionFields_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "es",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "es",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "es",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactExtensionValues",
                schema: "es",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtensionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactExtensionValues", x => new { x.ContactId, x.ExtensionFieldId });
                    table.ForeignKey(
                        name: "FK_ContactExtensionValues_ContactExtensionFields_ExtensionFieldId",
                        column: x => x.ExtensionFieldId,
                        principalSchema: "es",
                        principalTable: "ContactExtensionFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactExtensionValues_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "es",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactExtensionFields_TenantId",
                schema: "es",
                table: "ContactExtensionFields",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactExtensionValues_ExtensionFieldId",
                schema: "es",
                table: "ContactExtensionValues",
                column: "ExtensionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TenantId",
                schema: "es",
                table: "Contacts",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactExtensionValues",
                schema: "es");

            migrationBuilder.DropTable(
                name: "ContactExtensionFields",
                schema: "es");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "es");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "es");
        }
    }
}
