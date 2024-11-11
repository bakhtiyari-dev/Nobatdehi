using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Plans_Self_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Plans_PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.CreateTable(
                name: "PlanDependencies",
                schema: "Plan",
                columns: table => new
                {
                    Dependencies = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDependencies", x => new { x.Dependencies, x.PlanId });
                    table.ForeignKey(
                        name: "FK_PlanDependencies_Plans_Dependencies",
                        column: x => x.Dependencies,
                        principalSchema: "Plan",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDependencies_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Plan",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanDependencies_PlanId",
                schema: "Plan",
                table: "PlanDependencies",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDependencies",
                schema: "Plan");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                schema: "Plan",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanId",
                schema: "Plan",
                table: "Plans",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Plans_PlanId",
                schema: "Plan",
                table: "Plans",
                column: "PlanId",
                principalSchema: "Plan",
                principalTable: "Plans",
                principalColumn: "Id");
        }
    }
}
