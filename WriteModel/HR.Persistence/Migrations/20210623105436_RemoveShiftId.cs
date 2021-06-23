using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class RemoveShiftId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextShift",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate",
                type: "UniqueIdentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NextShiftId",
                schema: "ShiftContext",
                table: "Shift",
                type: "UniqueIdentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTemplate_ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIo_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeIo_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                column: "EmployeeId",
                principalSchema: "EmployeeContext",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftTemplate_Shift_ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate",
                column: "ShiftId",
                principalSchema: "ShiftContext",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeIo_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftTemplate_Shift_ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate");

            migrationBuilder.DropIndex(
                name: "IX_ShiftTemplate_ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeIo_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                schema: "ShiftContext",
                table: "ShiftTemplate");

            migrationBuilder.DropColumn(
                name: "NextShiftId",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.AddColumn<long>(
                name: "NextShift",
                schema: "ShiftContext",
                table: "Shift",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShiftId",
                schema: "ShiftContext",
                table: "Shift",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
