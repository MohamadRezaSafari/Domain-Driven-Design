using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class AddForigenkeyEmployeeEmployeeIO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeId_To_EmployeeIO",
                table: "EmployeeIo",
                column: "EmployeeId",
                principalTable: "Employee",
                schema: "EmployeeContext",
                principalSchema: "EmployeeContext",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeId_To_EmployeeIO",
                table: "EmployeeIo",
                schema: "EmployeeContext");
        }
    }
}
