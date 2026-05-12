using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTPMQL_MVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_DeviceCategory_DeviceCategoryCategoryID",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportDetail_Device_DeviceID",
                table: "ExportDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportDetail_ExportReceipt_ExportReceiptID",
                table: "ExportDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetail_Device_DeviceID",
                table: "ImportDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetail_ImportReceipt_ImportReceiptID",
                table: "ImportDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportReceipt_Supplier_SupplierID",
                table: "ImportReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportReceipt",
                table: "ImportReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportDetail",
                table: "ImportDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExportReceipt",
                table: "ExportReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExportDetail",
                table: "ExportDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceCategory",
                table: "DeviceCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_DeviceCategoryCategoryID",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DeviceCategoryCategoryID",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ImportReceipt",
                newName: "ImportReceipts");

            migrationBuilder.RenameTable(
                name: "ImportDetail",
                newName: "ImportDetails");

            migrationBuilder.RenameTable(
                name: "ExportReceipt",
                newName: "ExportReceipts");

            migrationBuilder.RenameTable(
                name: "ExportDetail",
                newName: "ExportDetails");

            migrationBuilder.RenameTable(
                name: "DeviceCategory",
                newName: "DeviceCategories");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_ImportReceipt_SupplierID",
                table: "ImportReceipts",
                newName: "IX_ImportReceipts_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_ImportDetail_ImportReceiptID",
                table: "ImportDetails",
                newName: "IX_ImportDetails_ImportReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ImportDetail_DeviceID",
                table: "ImportDetails",
                newName: "IX_ImportDetails_DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_ExportDetail_ExportReceiptID",
                table: "ExportDetails",
                newName: "IX_ExportDetails_ExportReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ExportDetail_DeviceID",
                table: "ExportDetails",
                newName: "IX_ExportDetails_DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportReceipts",
                table: "ImportReceipts",
                column: "ImportReceiptID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportDetails",
                table: "ImportDetails",
                column: "ImportDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExportReceipts",
                table: "ExportReceipts",
                column: "ExportReceiptID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExportDetails",
                table: "ExportDetails",
                column: "ExportDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceCategories",
                table: "DeviceCategories",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "DeviceID");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    PublishYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CategoryID",
                table: "Devices",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategories_CategoryID",
                table: "Devices",
                column: "CategoryID",
                principalTable: "DeviceCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportDetails_Devices_DeviceID",
                table: "ExportDetails",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportDetails_ExportReceipts_ExportReceiptID",
                table: "ExportDetails",
                column: "ExportReceiptID",
                principalTable: "ExportReceipts",
                principalColumn: "ExportReceiptID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_Devices_DeviceID",
                table: "ImportDetails",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_ImportReceipts_ImportReceiptID",
                table: "ImportDetails",
                column: "ImportReceiptID",
                principalTable: "ImportReceipts",
                principalColumn: "ImportReceiptID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportReceipts_Suppliers_SupplierID",
                table: "ImportReceipts",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategories_CategoryID",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportDetails_Devices_DeviceID",
                table: "ExportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportDetails_ExportReceipts_ExportReceiptID",
                table: "ExportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_Devices_DeviceID",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_ImportReceipts_ImportReceiptID",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportReceipts_Suppliers_SupplierID",
                table: "ImportReceipts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportReceipts",
                table: "ImportReceipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportDetails",
                table: "ImportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExportReceipts",
                table: "ExportReceipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExportDetails",
                table: "ExportDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CategoryID",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceCategories",
                table: "DeviceCategories");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "ImportReceipts",
                newName: "ImportReceipt");

            migrationBuilder.RenameTable(
                name: "ImportDetails",
                newName: "ImportDetail");

            migrationBuilder.RenameTable(
                name: "ExportReceipts",
                newName: "ExportReceipt");

            migrationBuilder.RenameTable(
                name: "ExportDetails",
                newName: "ExportDetail");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameTable(
                name: "DeviceCategories",
                newName: "DeviceCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ImportReceipts_SupplierID",
                table: "ImportReceipt",
                newName: "IX_ImportReceipt_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_ImportDetails_ImportReceiptID",
                table: "ImportDetail",
                newName: "IX_ImportDetail_ImportReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ImportDetails_DeviceID",
                table: "ImportDetail",
                newName: "IX_ImportDetail_DeviceID");

            migrationBuilder.RenameIndex(
                name: "IX_ExportDetails_ExportReceiptID",
                table: "ExportDetail",
                newName: "IX_ExportDetail_ExportReceiptID");

            migrationBuilder.RenameIndex(
                name: "IX_ExportDetails_DeviceID",
                table: "ExportDetail",
                newName: "IX_ExportDetail_DeviceID");

            migrationBuilder.AddColumn<int>(
                name: "DeviceCategoryCategoryID",
                table: "Device",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportReceipt",
                table: "ImportReceipt",
                column: "ImportReceiptID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportDetail",
                table: "ImportDetail",
                column: "ImportDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExportReceipt",
                table: "ExportReceipt",
                column: "ExportReceiptID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExportDetail",
                table: "ExportDetail",
                column: "ExportDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "DeviceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceCategory",
                table: "DeviceCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceCategoryCategoryID",
                table: "Device",
                column: "DeviceCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_DeviceCategory_DeviceCategoryCategoryID",
                table: "Device",
                column: "DeviceCategoryCategoryID",
                principalTable: "DeviceCategory",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportDetail_Device_DeviceID",
                table: "ExportDetail",
                column: "DeviceID",
                principalTable: "Device",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportDetail_ExportReceipt_ExportReceiptID",
                table: "ExportDetail",
                column: "ExportReceiptID",
                principalTable: "ExportReceipt",
                principalColumn: "ExportReceiptID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetail_Device_DeviceID",
                table: "ImportDetail",
                column: "DeviceID",
                principalTable: "Device",
                principalColumn: "DeviceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetail_ImportReceipt_ImportReceiptID",
                table: "ImportDetail",
                column: "ImportReceiptID",
                principalTable: "ImportReceipt",
                principalColumn: "ImportReceiptID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportReceipt_Supplier_SupplierID",
                table: "ImportReceipt",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
