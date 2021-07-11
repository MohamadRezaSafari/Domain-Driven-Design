using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ShiftSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "NextShift",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "ShiftTemplateId",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "ShiftContext",
                table: "Shift");

            migrationBuilder.CreateTable(
                name: "ShiftSegment",
                schema: "ShiftContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NextShiftId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftSegment",
                        column: x => x.ShiftId,
                        principalSchema: "ShiftContext",
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIo_EmployeeId2",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftSegment_ShiftId",
                schema: "ShiftContext",
                table: "ShiftSegment",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeIo_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                column: "EmployeeId",
                principalSchema: "EmployeeContext",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeIo_Employee_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo");

            migrationBuilder.DropTable(
                name: "ShiftSegment",
                schema: "ShiftContext");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeIo_EmployeeId2",
                schema: "EmployeeContext",
                table: "EmployeeIo");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                schema: "ShiftContext",
                table: "Shift",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

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

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftTemplateId",
                schema: "ShiftContext",
                table: "Shift",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                schema: "ShiftContext",
                table: "Shift",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
