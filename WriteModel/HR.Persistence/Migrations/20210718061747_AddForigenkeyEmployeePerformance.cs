using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class AddForigenkeyEmployeePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Performance_EmployeeId",
                schema: "EmployeeContext",
                table: "Performance",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "Performance",
                column: "EmployeeId",
                principalSchema: "EmployeeContext",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_EmployeeId",
                schema: "EmployeeContext",
                table: "Performance");
        }
    }
}
