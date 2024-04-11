using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    ActiveTaskId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskHistories",
                columns: table => new
                {
                    TaskHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistories", x => x.TaskHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<byte>(type: "tinyint", nullable: false),
                    DifficultyColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "ActiveTaskId", "Name", "Surname", "TotalScore" },
                values: new object[,]
                {
                    { 1, (byte)1, "Ahmet", "Kılıç", 1 },
                    { 2, (byte)2, "Ayşe", "Yılmaz", 2 },
                    { 3, (byte)3, "Mehmet", "Kaya", 3 },
                    { 4, (byte)4, "Fatma", "Aslan", 4 },
                    { 5, (byte)5, "Ali", "Şahin", 5 },
                    { 6, (byte)6, "Merve", "Ak", 6 }
                });

            migrationBuilder.InsertData(
                table: "TaskHistories",
                columns: new[] { "TaskHistoryId", "EmployeeId", "TaskDate", "TaskId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9756), 1 },
                    { 2, 2, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9773), 2 },
                    { 3, 3, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9774), 3 },
                    { 4, 4, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9775), 4 },
                    { 5, 5, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9777), 5 },
                    { 6, 6, new DateTime(2024, 4, 9, 22, 16, 40, 452, DateTimeKind.Local).AddTicks(9778), 6 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Difficulty", "DifficultyColorCode", "Name" },
                values: new object[,]
                {
                    { 1, (byte)1, "#00FF00", "Easy Task" },
                    { 2, (byte)2, "#33FF00", "Simple Task" },
                    { 3, (byte)3, "#66FF00", "Basic Task" },
                    { 4, (byte)4, "#99FF00", "Intermediate Task" },
                    { 5, (byte)5, "#CCFF00", "Advanced Task" },
                    { 6, (byte)6, "#FF0000", "Difficult Task" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TaskHistories");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
