using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "menu",
                schema: "security",
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
                name: "users",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    mac = table.Column<string>(type: "text", nullable: true),
                    ip = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    isloggedin = table.Column<bool>(type: "boolean", nullable: true),
                    lastloggedin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    loginexpiretime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    userstatus = table.Column<int>(type: "integer", nullable: false),
                    entryby = table.Column<string>(type: "text", nullable: false),
                    entrydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deletedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "submodule",
                schema: "security",
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
                        principalSchema: "security",
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                schema: "security",
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
                    table.PrimaryKey("pk_userroles", x => x.id);
                    table.ForeignKey(
                        name: "fk_userroles_users_userid",
                        column: x => x.userid,
                        principalSchema: "security",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userstatus",
                schema: "security",
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
                    table.PrimaryKey("pk_userstatus", x => x.id);
                    table.ForeignKey(
                        name: "fk_userstatus_users_userid",
                        column: x => x.userid,
                        principalSchema: "security",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "modulerole",
                schema: "security",
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
                        name: "fk_modulerole_userroles_userroleid",
                        column: x => x.userroleid,
                        principalSchema: "security",
                        principalTable: "userroles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "submodulefunction",
                schema: "security",
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
                        principalSchema: "security",
                        principalTable: "submodule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_submodulefunction_userroles_userroleid",
                        column: x => x.userroleid,
                        principalSchema: "security",
                        principalTable: "userroles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "security",
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
                        principalSchema: "security",
                        principalTable: "modulerole",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_module_moduleroleid",
                schema: "security",
                table: "module",
                column: "moduleroleid");

            migrationBuilder.CreateIndex(
                name: "ix_modulerole_userroleid",
                schema: "security",
                table: "modulerole",
                column: "userroleid");

            migrationBuilder.CreateIndex(
                name: "ix_submodule_menuid",
                schema: "security",
                table: "submodule",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "ix_submodulefunction_submoduleid",
                schema: "security",
                table: "submodulefunction",
                column: "submoduleid");

            migrationBuilder.CreateIndex(
                name: "ix_submodulefunction_userroleid",
                schema: "security",
                table: "submodulefunction",
                column: "userroleid");

            migrationBuilder.CreateIndex(
                name: "ix_userroles_userid",
                schema: "security",
                table: "userroles",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_userstatus_userid",
                schema: "security",
                table: "userstatus",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "module",
                schema: "security");

            migrationBuilder.DropTable(
                name: "submodulefunction",
                schema: "security");

            migrationBuilder.DropTable(
                name: "userstatus",
                schema: "security");

            migrationBuilder.DropTable(
                name: "modulerole",
                schema: "security");

            migrationBuilder.DropTable(
                name: "submodule",
                schema: "security");

            migrationBuilder.DropTable(
                name: "userroles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "menu",
                schema: "security");

            migrationBuilder.DropTable(
                name: "users",
                schema: "security");
        }
    }
}
