using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class EmployeeShiftAssignChangeTimeToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                newName: "EndTime");
        }
    }
}
