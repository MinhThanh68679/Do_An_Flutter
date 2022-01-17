using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Insert_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "MaSp", "Delete_Date", "LoaiSanPham", "Status", "TenSP", "Update_Date" },
                values: new object[,]
                {
                    { "SP_1", new DateTime(2021, 12, 18, 19, 0, 22, 810, DateTimeKind.Local).AddTicks(1169), "Áo", true, "Áo thun đi biển", new DateTime(2021, 12, 18, 19, 0, 22, 808, DateTimeKind.Local).AddTicks(9044) },
                    { "SP_2", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9651), "quần", true, "quần bơi", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9630) },
                    { "SP_3", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9834), "Áo", true, "Áo thun tay dài", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9830) },
                    { "SP_4", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9874), "Áo", true, "Áo thun tay ngắn", new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9871) }
                });

            migrationBuilder.InsertData(
                table: "ChiTietSanPhams",
                columns: new[] { "MaCTSP", "Anh", "Color", "DonGia", "GioTinh", "MoTaSP", "SL", "SanPhamMaSP", "Size" },
                values: new object[,]
                {
                    { "CTSP_01", "", "Trắng, Xanh, Vàng", 30.0, "Nam", "", 10, "SP_1", "M,X,XL" },
                    { "CTSP_02", "", "Đen, Xanh", 30.0, "Nam", "", 10, "SP_2", "M,X" },
                    { "CTSP_03", "", "Xám, Đen, Vàng, Lục", 30.0, "Nữ", "", 10, "SP_3", "S,M" },
                    { "CTSP_04", "", "Trắng, Đen, Đỏ, Xanh", 30.0, "UniSex", "", 10, "SP_4", "S,M,X" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChiTietSanPhams",
                keyColumn: "MaCTSP",
                keyValue: "CTSP_01");

            migrationBuilder.DeleteData(
                table: "ChiTietSanPhams",
                keyColumn: "MaCTSP",
                keyValue: "CTSP_02");

            migrationBuilder.DeleteData(
                table: "ChiTietSanPhams",
                keyColumn: "MaCTSP",
                keyValue: "CTSP_03");

            migrationBuilder.DeleteData(
                table: "ChiTietSanPhams",
                keyColumn: "MaCTSP",
                keyValue: "CTSP_04");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_1");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_2");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_3");

            migrationBuilder.DeleteData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_4");
        }
    }
}
