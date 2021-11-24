using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DManage.SystemManagement.Infrastructure.Persistence.Migrations
{
    public partial class remove_autogeenrated_productreferenceid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ReferenceId",
                table: "ProductType",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductType_ReferenceId",
                table: "ProductType");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReferenceId",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
