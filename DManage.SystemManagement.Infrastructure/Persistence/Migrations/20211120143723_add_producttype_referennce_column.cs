using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DManage.SystemManagement.Infrastructure.Persistence.Migrations
{
    public partial class add_producttype_referennce_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceId",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "ProductType");
        }
    }
}
