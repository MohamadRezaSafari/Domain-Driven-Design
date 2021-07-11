using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ChangeShiftIdToShiftSegmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftId",
                schema: "EmployeeContext",
                table: "ShiftAssignment");

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftSegmentId",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftSegmentId",
                schema: "EmployeeContext",
                table: "ShiftAssignment");

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftId",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
