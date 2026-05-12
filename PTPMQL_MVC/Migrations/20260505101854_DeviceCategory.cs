using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTPMQL_MVC.Migrations
{
    /// <inheritdoc />
    public partial class DeviceCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ExportReceipt",
                columns: table => new
                {
                    ExportReceiptID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceipt", x => x.ExportReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeviceName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceCategoryCategoryID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Device_DeviceCategory_DeviceCategoryCategoryID",
                        column: x => x.DeviceCategoryCategoryID,
                        principalTable: "DeviceCategory",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "ImportReceipt",
                columns: table => new
                {
                    ImportReceiptID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipt", x => x.ImportReceiptID);
                    table.ForeignKey(
                        name: "FK_ImportReceipt_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetail",
                columns: table => new
                {
                    ExportDetailID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportReceiptID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceID = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetail", x => x.ExportDetailID);
                    table.ForeignKey(
                        name: "FK_ExportDetail_Device_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ExportReceipt_ExportReceiptID",
                        column: x => x.ExportReceiptID,
                        principalTable: "ExportReceipt",
                        principalColumn: "ExportReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetail",
                columns: table => new
                {
                    ImportDetailID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportReceiptID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceID = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetail", x => x.ImportDetailID);
                    table.ForeignKey(
                        name: "FK_ImportDetail_Device_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportDetail_ImportReceipt_ImportReceiptID",
                        column: x => x.ImportReceiptID,
                        principalTable: "ImportReceipt",
                        principalColumn: "ImportReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceCategoryCategoryID",
                table: "Device",
                column: "DeviceCategoryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_DeviceID",
                table: "ExportDetail",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ExportReceiptID",
                table: "ExportDetail",
                column: "ExportReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_DeviceID",
                table: "ImportDetail",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_ImportReceiptID",
                table: "ImportDetail",
                column: "ImportReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipt_SupplierID",
                table: "ImportReceipt",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportDetail");

            migrationBuilder.DropTable(
                name: "ImportDetail");

            migrationBuilder.DropTable(
                name: "ExportReceipt");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "ImportReceipt");

            migrationBuilder.DropTable(
                name: "DeviceCategory");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
