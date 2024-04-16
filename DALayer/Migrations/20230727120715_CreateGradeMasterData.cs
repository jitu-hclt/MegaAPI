using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALayer.Migrations
{
    public partial class CreateGradeMasterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Grades(Name) Values('6th')");
            migrationBuilder.Sql("Insert into Grades(Name) Values('7th')");
            migrationBuilder.Sql("Insert into Grades(Name) Values('8th')");
            migrationBuilder.Sql("Insert into Grades(Name) Values('9th')");
            migrationBuilder.Sql("Insert into Grades(Name) Values('High School')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Truncate Table Grades");
        }
    }
}
