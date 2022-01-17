using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class fixColumntableCChitietHoaDon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_KhachHangs_KhachHangMaKH",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "KhachHangMaKH",
                table: "ChiTietHoaDons",
                newName: "SanPhamMaSp");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_KhachHangMaKH",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_SanPhamMaSp");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_SanPhamMaSp",
                table: "ChiTietHoaDons",
                column: "SanPhamMaSp",
                principalTable: "SanPhams",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDons_SanPhams_SanPhamMaSp",
                table: "ChiTietHoaDons");

            migrationBuilder.RenameColumn(
                name: "SanPhamMaSp",
                table: "ChiTietHoaDons",
                newName: "KhachHangMaKH");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietHoaDons_SanPhamMaSp",
                table: "ChiTietHoaDons",
                newName: "IX_ChiTietHoaDons_KhachHangMaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDons_KhachHangs_KhachHangMaKH",
                table: "ChiTietHoaDons",
                column: "KhachHangMaKH",
                principalTable: "KhachHangs",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
