using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Desabled_Turns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Day",
                schema: "OPtion",
                table: "WeekPlans",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Turn",
                table: "Turns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DesabledTurn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateOnly>(type: "date", nullable: false),
                    Hour = table.Column<TimeOnly>(type: "time", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesabledTurn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesabledTurn_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "Office",
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesabledTurn_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Plan",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesabledTurn_OfficeId",
                table: "DesabledTurn",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_DesabledTurn_PlanId",
                table: "DesabledTurn",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesabledTurn");

            migrationBuilder.AlterColumn<int>(
                name: "Day",
                schema: "OPtion",
                table: "WeekPlans",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Turn",
                table: "Turns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
