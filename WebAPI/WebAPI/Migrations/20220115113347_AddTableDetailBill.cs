using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddTableDetailBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    HoaDonMaHD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhachHangMaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => new { x.HoaDonMaHD, x.KhachHangMaKH });
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_HoaDonMaHD",
                        column: x => x.HoaDonMaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_KhachHangs_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_KhachHangMaKH",
                table: "ChiTietHoaDons",
                column: "KhachHangMaKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");
        }
    }
}
