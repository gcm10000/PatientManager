using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManager.Sql.Migrations
{
    public partial class AddHealthInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HealthInsurance",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthInsurance",
                table: "Patients");
        }
    }
}
