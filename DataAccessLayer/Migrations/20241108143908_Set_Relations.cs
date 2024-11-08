using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Set_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependencies",
                schema: "Option");

            migrationBuilder.DropColumn(
                name: "PlanOptionId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TurnPoolId",
                schema: "Option",
                table: "OfficePlanOptions");

            migrationBuilder.DropColumn(
                name: "WeekPlanId",
                schema: "Option",
                table: "OfficePlanOptions");

            migrationBuilder.RenameColumn(
                name: "OfficeOptionPlanId",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "OfficePlanOptionId");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                schema: "Plan",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekPlans_OfficePlanOptionId",
                schema: "OPtion",
                table: "WeekPlans",
                column: "OfficePlanOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_CitizenId",
                schema: "Turn",
                table: "Turns",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_OfficeId",
                schema: "Turn",
                table: "Turns",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_PlanId",
                schema: "Turn",
                table: "Turns",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnPools_OfficePlanOptionId",
                schema: "Turn",
                table: "TurnPools",
                column: "OfficePlanOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanId",
                schema: "Plan",
                table: "Plans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanOptions_PlanId",
                schema: "Option",
                table: "PlanOptions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offices_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId",
                principalSchema: "Office",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanOptions_Plans_PlanId",
                schema: "Option",
                table: "PlanOptions",
                column: "PlanId",
                principalSchema: "Plan",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Plans_PlanId",
                schema: "Plan",
                table: "Plans",
                column: "PlanId",
                principalSchema: "Plan",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TurnPools_OfficePlanOptions_OfficePlanOptionId",
                schema: "Turn",
                table: "TurnPools",
                column: "OfficePlanOptionId",
                principalSchema: "Option",
                principalTable: "OfficePlanOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Citizens_CitizenId",
                schema: "Turn",
                table: "Turns",
                column: "CitizenId",
                principalSchema: "Member",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Offices_OfficeId",
                schema: "Turn",
                table: "Turns",
                column: "OfficeId",
                principalSchema: "Office",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Plans_PlanId",
                schema: "Turn",
                table: "Turns",
                column: "PlanId",
                principalSchema: "Plan",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekPlans_OfficePlanOptions_OfficePlanOptionId",
                schema: "OPtion",
                table: "WeekPlans",
                column: "OfficePlanOptionId",
                principalSchema: "Option",
                principalTable: "OfficePlanOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offices_OfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanOptions_Plans_PlanId",
                schema: "Option",
                table: "PlanOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Plans_PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_TurnPools_OfficePlanOptions_OfficePlanOptionId",
                schema: "Turn",
                table: "TurnPools");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Citizens_CitizenId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Offices_OfficeId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Plans_PlanId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekPlans_OfficePlanOptions_OfficePlanOptionId",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropIndex(
                name: "IX_WeekPlans_OfficePlanOptionId",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropIndex(
                name: "IX_Turns_CitizenId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_OfficeId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_PlanId",
                schema: "Turn",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_TurnPools_OfficePlanOptionId",
                schema: "Turn",
                table: "TurnPools");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_PlanOptions_PlanId",
                schema: "Option",
                table: "PlanOptions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfficeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "OfficePlanOptionId",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "OfficeOptionPlanId");

            migrationBuilder.AddColumn<int>(
                name: "PlanOptionId",
                schema: "Plan",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnPoolId",
                schema: "Option",
                table: "OfficePlanOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekPlanId",
                schema: "Option",
                table: "OfficePlanOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dependencies",
                schema: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    PlanOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencies", x => x.Id);
                });
        }
    }
}
