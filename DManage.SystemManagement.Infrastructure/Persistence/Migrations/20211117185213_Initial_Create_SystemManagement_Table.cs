using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DManage.SystemManagement.Infrastructure.Persistence.Migrations
{
    public partial class Initial_Create_SystemManagement_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NodeCount = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicensePlateNumber",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePlateNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicensePlateNumber_Node_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Node",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseNodeMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseNodeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouseNodeMapping_Node_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Node",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WareHouseNodeMapping_WareHouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseProductTypeMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseProductTypeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouseProductTypeMapping_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WareHouseProductTypeMapping_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pallet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    LicensePlateNumberId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pallet_LicensePlateNumber_LicensePlateNumberId",
                        column: x => x.LicensePlateNumberId,
                        principalTable: "LicensePlateNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pallet_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicensePlateNumber_NodeId",
                table: "LicensePlateNumber",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallet_LicensePlateNumberId",
                table: "Pallet",
                column: "LicensePlateNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallet_ProductTypeId",
                table: "Pallet",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseNodeMapping_NodeId",
                table: "WareHouseNodeMapping",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseNodeMapping_WarehouseId",
                table: "WareHouseNodeMapping",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseProductTypeMapping_ProductTypeId",
                table: "WareHouseProductTypeMapping",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseProductTypeMapping_WareHouseId",
                table: "WareHouseProductTypeMapping",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pallet");

            migrationBuilder.DropTable(
                name: "WareHouseNodeMapping");

            migrationBuilder.DropTable(
                name: "WareHouseProductTypeMapping");

            migrationBuilder.DropTable(
                name: "LicensePlateNumber");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropTable(
                name: "Node");
        }
    }
}
