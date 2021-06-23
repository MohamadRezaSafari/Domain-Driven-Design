using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class ChangeTypeEmployeeId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "UniqueIdentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeIo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UniqueIdentifier");
        }
    }
}
