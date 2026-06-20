using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTPMQL_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Buoi12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ExportReceipt",
                columns: table => new
                {
                    ExportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceipt", x => x.ExportId);
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
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeviceName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Device_DeviceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DeviceCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Device_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportReceipt",
                columns: table => new
                {
                    ImportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReceipt", x => x.ImportId);
                    table.ForeignKey(
                        name: "FK_ImportReceipt_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetail",
                columns: table => new
                {
                    ExportDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExportReceiptExportId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetail", x => x.ExportDetailId);
                    table.ForeignKey(
                        name: "FK_ExportDetail_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ExportReceipt_ExportReceiptExportId",
                        column: x => x.ExportReceiptExportId,
                        principalTable: "ExportReceipt",
                        principalColumn: "ExportId");
                });

            migrationBuilder.CreateTable(
                name: "ImportDetail",
                columns: table => new
                {
                    ImportDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImportReceiptImportId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetail", x => x.ImportDetailId);
                    table.ForeignKey(
                        name: "FK_ImportDetail_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportDetail_ImportReceipt_ImportReceiptImportId",
                        column: x => x.ImportReceiptImportId,
                        principalTable: "ImportReceipt",
                        principalColumn: "ImportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_CategoryId",
                table: "Device",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_SupplierId",
                table: "Device",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_DeviceId",
                table: "ExportDetail",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ExportReceiptExportId",
                table: "ExportDetail",
                column: "ExportReceiptExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_DeviceId",
                table: "ImportDetail",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_ImportReceiptImportId",
                table: "ImportDetail",
                column: "ImportReceiptImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportReceipt_SupplierId",
                table: "ImportReceipt",
                column: "SupplierId");
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
