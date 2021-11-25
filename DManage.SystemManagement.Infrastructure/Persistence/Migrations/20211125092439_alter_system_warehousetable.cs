using Microsoft.EntityFrameworkCore.Migrations;

namespace DManage.SystemManagement.Infrastructure.Persistence.Migrations
{
    public partial class alter_system_warehousetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeCount",
                table: "WareHouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NodeCount",
                table: "WareHouse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
