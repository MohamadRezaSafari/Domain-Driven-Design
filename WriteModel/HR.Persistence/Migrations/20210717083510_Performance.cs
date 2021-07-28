using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class Performance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performance",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceDetail",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ShiftSegmentId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Sum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performance",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "PerformanceDetail",
                schema: "EmployeeContext");
        }
    }
}
