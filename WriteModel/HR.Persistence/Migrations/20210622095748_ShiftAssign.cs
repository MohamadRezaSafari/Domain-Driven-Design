using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ShiftAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeIo_Employee_EmployeeId",
            //    schema: "EmployeeContext",
            //    table: "EmployeeIo");

            //migrationBuilder.DropIndex(
            //    name: "IX_EmployeeIo_EmployeeId",
            //    schema: "EmployeeContext",
            //    table: "EmployeeIo");

            //migrationBuilder.CreateTable(
            //    name: "Shift",
            //    schema: "ShiftContext",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
            //        ShiftId = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ShiftTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
            //        EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
            //        NextShift = table.Column<long>(type: "bigint", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Shift", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "ShiftAssignment",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftAssignment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignment_EmployeeId",
                schema: "EmployeeContext",
                table: "ShiftAssignment",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shift",
                schema: "ShiftContext");

            migrationBuilder.DropTable(
                name: "ShiftAssignment",
                schema: "EmployeeContext");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EmployeeIo_EmployeeId",
            //    schema: "EmployeeContext",
            //    table: "EmployeeIo",
            //    column: "EmployeeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeIo_Employee_EmployeeId",
            //    schema: "EmployeeContext",
            //    table: "EmployeeIo",
            //    column: "EmployeeId",
            //    principalSchema: "EmployeeContext",
            //    principalTable: "Employee",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
