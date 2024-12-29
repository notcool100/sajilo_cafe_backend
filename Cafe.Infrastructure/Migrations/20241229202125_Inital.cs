using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cafe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cafe");

            migrationBuilder.CreateTable(
                name: "menu",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tooltip = table.Column<string>(type: "text", nullable: true),
                    orderno = table.Column<double>(type: "double precision", nullable: true),
                    murl = table.Column<string>(type: "text", nullable: true),
                    parent = table.Column<Guid>(type: "uuid", nullable: true),
                    haschild = table.Column<string>(type: "text", nullable: true),
                    menuicon = table.Column<string>(type: "text", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_menu", x => x.id);
                });

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
                name: "submodule",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    menuid = table.Column<Guid>(type: "uuid", nullable: false),
                    functions = table.Column<int[]>(type: "integer[]", nullable: false),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_submodule", x => x.id);
                    table.ForeignKey(
                        name: "fk_submodule_menu_menuid",
                        column: x => x.menuid,
                        principalSchema: "cafe",
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "user",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    mac = table.Column<string>(type: "text", nullable: true),
                    ip = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    isloggedin = table.Column<bool>(type: "boolean", nullable: true),
                    lastloggedin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    loginexpiretime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    userstatus = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    cafemid = table.Column<Guid>(type: "uuid", nullable: true),
                    discriminator = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    cafeid = table.Column<Guid>(type: "uuid", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_cafes_cafeid",
                        column: x => x.cafeid,
                        principalSchema: "cafe",
                        principalTable: "cafes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_cafes_cafemid",
                        column: x => x.cafemid,
                        principalSchema: "cafe",
                        principalTable: "cafes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userrole", x => x.id);
                    table.ForeignKey(
                        name: "fk_userrole_user_userid",
                        column: x => x.userid,
                        principalSchema: "cafe",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userstatuslog",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userstatus = table.Column<string>(type: "text", nullable: false),
                    authno = table.Column<string>(type: "text", nullable: true),
                    authby = table.Column<string>(type: "text", nullable: true),
                    authdate = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userstatuslog", x => x.id);
                    table.ForeignKey(
                        name: "fk_userstatuslog_user_userid",
                        column: x => x.userid,
                        principalSchema: "cafe",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "modulerole",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    userroleid = table.Column<Guid>(type: "uuid", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_modulerole", x => x.id);
                    table.ForeignKey(
                        name: "fk_modulerole_userrole_userroleid",
                        column: x => x.userroleid,
                        principalSchema: "cafe",
                        principalTable: "userrole",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "submodulefunction",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    submoduleid = table.Column<Guid>(type: "uuid", nullable: false),
                    functions = table.Column<int[]>(type: "integer[]", nullable: false),
                    userroleid = table.Column<Guid>(type: "uuid", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_submodulefunction", x => x.id);
                    table.ForeignKey(
                        name: "fk_submodulefunction_submodule_submoduleid",
                        column: x => x.submoduleid,
                        principalSchema: "cafe",
                        principalTable: "submodule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_submodulefunction_userrole_userroleid",
                        column: x => x.userroleid,
                        principalSchema: "cafe",
                        principalTable: "userrole",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "cafe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    moduleroleid = table.Column<Guid>(type: "uuid", nullable: true),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module", x => x.id);
                    table.ForeignKey(
                        name: "fk_module_modulerole_moduleroleid",
                        column: x => x.moduleroleid,
                        principalSchema: "cafe",
                        principalTable: "modulerole",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_cafes_subscriptionid",
                schema: "cafe",
                table: "cafes",
                column: "subscriptionid");

            migrationBuilder.CreateIndex(
                name: "ix_module_moduleroleid",
                schema: "cafe",
                table: "module",
                column: "moduleroleid");

            migrationBuilder.CreateIndex(
                name: "ix_modulerole_userroleid",
                schema: "cafe",
                table: "modulerole",
                column: "userroleid");

            migrationBuilder.CreateIndex(
                name: "ix_submodule_menuid",
                schema: "cafe",
                table: "submodule",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "ix_submodulefunction_submoduleid",
                schema: "cafe",
                table: "submodulefunction",
                column: "submoduleid");

            migrationBuilder.CreateIndex(
                name: "ix_submodulefunction_userroleid",
                schema: "cafe",
                table: "submodulefunction",
                column: "userroleid");

            migrationBuilder.CreateIndex(
                name: "ix_user_cafeid",
                schema: "cafe",
                table: "user",
                column: "cafeid");

            migrationBuilder.CreateIndex(
                name: "ix_user_cafemid",
                schema: "cafe",
                table: "user",
                column: "cafemid");

            migrationBuilder.CreateIndex(
                name: "ix_userrole_userid",
                schema: "cafe",
                table: "userrole",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_userstatuslog_userid",
                schema: "cafe",
                table: "userstatuslog",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "module",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "submodulefunction",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "userstatuslog",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "modulerole",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "submodule",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "userrole",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "menu",
                schema: "cafe");

            migrationBuilder.DropTable(
                name: "user",
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
