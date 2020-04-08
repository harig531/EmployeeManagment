using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagment.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "PersonslId", "Department", "Email", "FirstName", "UserName" },
                values: new object[] { 1, 1, "Hari@gmail.com", "Hari", "hguntu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employee",
                keyColumn: "PersonslId",
                keyValue: 1);
        }
    }
}
