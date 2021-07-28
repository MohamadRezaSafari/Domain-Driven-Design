using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ChangePerformanceSumToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Sum",
                schema: "EmployeeContext",
                table: "PerformanceDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Sum",
                schema: "EmployeeContext",
                table: "Performance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                schema: "EmployeeContext",
                table: "PerformanceDetail");

            migrationBuilder.DropColumn(
                name: "Sum",
                schema: "EmployeeContext",
                table: "Performance");
        }
    }
}
