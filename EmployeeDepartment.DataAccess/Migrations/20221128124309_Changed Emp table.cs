using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDepartmentProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartID",
                table: "Employees",
                column: "DepartID",
                principalTable: "Departments",
                principalColumn: "DepartID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartID",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartID",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartID",
                table: "Employees",
                column: "DepartID",
                principalTable: "Departments",
                principalColumn: "DepartID");
        }
    }
}
