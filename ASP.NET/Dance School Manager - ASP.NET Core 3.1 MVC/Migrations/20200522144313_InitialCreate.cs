using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DanceSchool_10._05_ASP.NET_MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    ProductVersion = table.Column<string>(type: "varchar(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "dance_style",
                columns: table => new
                {
                    dancestyle_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dancestyle_name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dance_style", x => x.dancestyle_id);
                });

            migrationBuilder.CreateTable(
                name: "function",
                columns: table => new
                {
                    function_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    function_name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_function", x => x.function_id);
                });

            migrationBuilder.CreateTable(
                name: "hours",
                columns: table => new
                {
                    hour_id = table.Column<short>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    hour_start = table.Column<TimeSpan>(type: "time", nullable: true),
                    hour_end = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hours", x => x.hour_id);
                });

            migrationBuilder.CreateTable(
                name: "turnament_group",
                columns: table => new
                {
                    turnament_group_id = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    group_id = table.Column<int>(nullable: false),
                    place = table.Column<int>(nullable: false),
                    aword = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    turnament_name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    city = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "turnament_solo",
                columns: table => new
                {
                    dancer_id = table.Column<int>(nullable: false),
                    turnament_solo_id = table.Column<int>(nullable: false),
                    place = table.Column<int>(nullable: true),
                    aword = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    turnament_name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    city = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.turnament_solo_id, x.dancer_id });
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    group_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Supervisor_id = table.Column<int>(nullable: false),
                    group_name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    dancestyle_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_Group_Dance_style1",
                        column: x => x.dancestyle_id,
                        principalTable: "dance_style",
                        principalColumn: "dancestyle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dancer",
                columns: table => new
                {
                    dancer_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    function_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    surname = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    status = table.Column<string>(type: "varchar(35)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dancer", x => x.dancer_id);
                    table.ForeignKey(
                        name: "fk_Dancer_Function1",
                        column: x => x.function_id,
                        principalTable: "function",
                        principalColumn: "function_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    class_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dancestyle_id = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    group_id = table.Column<int>(nullable: false),
                    weekday_id = table.Column<int>(nullable: false),
                    hour_id = table.Column<int>(nullable: false),
                    classroom_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.class_id);
                    table.UniqueConstraint("AK_class_weekday_id", x => x.weekday_id);
                    table.ForeignKey(
                        name: "fk_Class_Group1",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_has_dancer",
                columns: table => new
                {
                    Group_group_id = table.Column<int>(nullable: false),
                    Dancer_dancer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Group_group_id, x.Dancer_dancer_id });
                    table.ForeignKey(
                        name: "fk_Group_has_Dancer_Dancer1",
                        column: x => x.Dancer_dancer_id,
                        principalTable: "dancer",
                        principalColumn: "dancer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Group_has_Dancer_Group1",
                        column: x => x.Group_group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "weekday",
                columns: table => new
                {
                    day_id = table.Column<int>(nullable: true),
                    day_name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "day_id",
                        column: x => x.day_id,
                        principalTable: "class",
                        principalColumn: "weekday_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_Class_Group1_idx",
                table: "class",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "hour_id_idx",
                table: "class",
                column: "hour_id");

            migrationBuilder.CreateIndex(
                name: "weekday_id_UNIQUE",
                table: "class",
                column: "weekday_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "dancestyle_id_UNIQUE",
                table: "dance_style",
                column: "dancestyle_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "dancer_id_UNIQUE",
                table: "dancer",
                column: "dancer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Dancer_Function1_idx",
                table: "dancer",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "fk_Group_Dance_style1_idx",
                table: "group",
                column: "dancestyle_id");

            migrationBuilder.CreateIndex(
                name: "group_id_UNIQUE",
                table: "group",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "group_name_UNIQUE",
                table: "group",
                column: "group_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Group_has_Dancer_Dancer1_idx",
                table: "group_has_dancer",
                column: "Dancer_dancer_id");

            migrationBuilder.CreateIndex(
                name: "fk_Group_has_Dancer_Group1_idx",
                table: "group_has_dancer",
                column: "Group_group_id");

            migrationBuilder.CreateIndex(
                name: "day_id_idx",
                table: "weekday",
                column: "day_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "group_has_dancer");

            migrationBuilder.DropTable(
                name: "hours");

            migrationBuilder.DropTable(
                name: "turnament_group");

            migrationBuilder.DropTable(
                name: "turnament_solo");

            migrationBuilder.DropTable(
                name: "weekday");

            migrationBuilder.DropTable(
                name: "dancer");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "function");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "dance_style");
        }
    }
}
