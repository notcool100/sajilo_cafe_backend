using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cafe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cafe");

            migrationBuilder.CreateTable(
                name: "subscriptions",
                schema: "cafe",
                columns: table => new
                {
                    subscriptionid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subscriptionname = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    durationmonths = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.subscriptionid);
                });

            migrationBuilder.CreateTable(
                name: "cafes",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    subscriptionid = table.Column<int>(type: "integer", nullable: true),
                    cafelogo = table.Column<byte[]>(type: "bytea", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cafes", x => x.id);
                    table.ForeignKey(
                        name: "fk_cafes_subscriptions_subscriptionid",
                        column: x => x.subscriptionid,
                        principalSchema: "cafe",
                        principalTable: "subscriptions",
                        principalColumn: "subscriptionid");
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cafeid = table.Column<Guid>(type: "uuid", nullable: false),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_cafes_cafeid",
                        column: x => x.cafeid,
                        principalSchema: "cafe",
                        principalTable: "cafes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cafes_subscriptionid",
                schema: "cafe",
                table: "cafes",
                column: "subscriptionid");

            migrationBuilder.CreateIndex(
                name: "ix_employees_cafeid",
                schema: "cafe",
                table: "employees",
                column: "cafeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "cafes",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "subscriptions",
                schema: "cafe");
        }
    }
}
