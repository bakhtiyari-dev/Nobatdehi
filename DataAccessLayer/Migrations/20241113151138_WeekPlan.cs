using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class WeekPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.RenameColumn(
                name: "ToHour",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "wednesdayLasttHour");

            migrationBuilder.RenameColumn(
                name: "FromHour",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "wednesdayFirstHour");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "MondayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "MondayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "SaterdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "SaterdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "SundayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "SundayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "fridayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "fridayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "thursdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "thursdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "tuesdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "tuesdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MondayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "MondayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "SaterdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "SaterdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "SundayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "SundayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "fridayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "fridayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "thursdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "thursdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "tuesdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.DropColumn(
                name: "tuesdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans");

            migrationBuilder.RenameColumn(
                name: "wednesdayLasttHour",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "ToHour");

            migrationBuilder.RenameColumn(
                name: "wednesdayFirstHour",
                schema: "OPtion",
                table: "WeekPlans",
                newName: "FromHour");

            migrationBuilder.AddColumn<byte>(
                name: "Day",
                schema: "OPtion",
                table: "WeekPlans",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
