using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Insert_seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GioHangs",
                columns: new[] { "KhachHangMaKH", "SanPhamMaSP", "Delete_Date", "Status", "Update_Date" },
                values: new object[,]
                {
                    { "Admin_1", "SP_4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Admin_3", "SP_1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Admin_3", "SP_2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HoaDons",
                columns: new[] { "MaHD", "Delete_Date", "GhiChu", "KhachHangMaKH", "NgayGiao", "Status", "TongTien", "Update_Date" },
                values: new object[,]
                {
                    { "HD01", new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note about alternative recipient,", "Admin_1", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 30.0, new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "HD02", new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note about alternative recipient", "Admin_1", new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 60.0, new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "HD03", new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Note about alternative recipient", "Admin_2", new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 60.0, new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ChiTietHoaDons",
                columns: new[] { "HoaDonMaHD", "SanPhamMaSp", "DonGia", "SL", "ThanhTien" },
                values: new object[,]
                {
                    { "HD01", "SP_1", 30.0, 1, 30.0 },
                    { "HD02", "SP_2", 30.0, 1, 30.0 },
                    { "HD02", "SP_3", 30.0, 1, 30.0 },
                    { "HD03", "SP_4", 30.0, 2, 60.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChiTietHoaDons",
                keyColumns: new[] { "HoaDonMaHD", "SanPhamMaSp" },
                keyValues: new object[] { "HD01", "SP_1" });

            migrationBuilder.DeleteData(
                table: "ChiTietHoaDons",
                keyColumns: new[] { "HoaDonMaHD", "SanPhamMaSp" },
                keyValues: new object[] { "HD02", "SP_2" });

            migrationBuilder.DeleteData(
                table: "ChiTietHoaDons",
                keyColumns: new[] { "HoaDonMaHD", "SanPhamMaSp" },
                keyValues: new object[] { "HD02", "SP_3" });

            migrationBuilder.DeleteData(
                table: "ChiTietHoaDons",
                keyColumns: new[] { "HoaDonMaHD", "SanPhamMaSp" },
                keyValues: new object[] { "HD03", "SP_4" });

            migrationBuilder.DeleteData(
                table: "GioHangs",
                keyColumns: new[] { "KhachHangMaKH", "SanPhamMaSP" },
                keyValues: new object[] { "Admin_3", "SP_1" });

            migrationBuilder.DeleteData(
                table: "GioHangs",
                keyColumns: new[] { "KhachHangMaKH", "SanPhamMaSP" },
                keyValues: new object[] { "Admin_3", "SP_2" });

            migrationBuilder.DeleteData(
                table: "GioHangs",
                keyColumns: new[] { "KhachHangMaKH", "SanPhamMaSP" },
                keyValues: new object[] { "Admin_1", "SP_4" });

            migrationBuilder.DeleteData(
                table: "HoaDons",
                keyColumn: "MaHD",
                keyValue: "HD01");

            migrationBuilder.DeleteData(
                table: "HoaDons",
                keyColumn: "MaHD",
                keyValue: "HD02");

            migrationBuilder.DeleteData(
                table: "HoaDons",
                keyColumn: "MaHD",
                keyValue: "HD03");
        }
    }
}
