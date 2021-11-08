using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyWebApplication.Data.Migrations
{
    public partial class withoutoverviewdto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "OverviewDto");
        }
    }
}
