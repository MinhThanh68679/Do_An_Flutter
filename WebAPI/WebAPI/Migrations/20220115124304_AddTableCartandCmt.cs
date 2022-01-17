using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddTableCartandCmt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BinhLuans",
                columns: table => new
                {
                    SanPhamMaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhachHangMaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuans", x => new { x.SanPhamMaSP, x.KhachHangMaKH });
                    table.ForeignKey(
                        name: "FK_BinhLuans_KhachHangs_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuans_SanPhams_SanPhamMaSP",
                        column: x => x.SanPhamMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    SanPhamMaSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhachHangMaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => new { x.SanPhamMaSP, x.KhachHangMaKH });
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangs_SanPhams_SanPhamMaSP",
                        column: x => x.SanPhamMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuans_KhachHangMaKH",
                table: "BinhLuans",
                column: "KhachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangMaKH",
                table: "GioHangs",
                column: "KhachHangMaKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuans");

            migrationBuilder.DropTable(
                name: "GioHangs");
        }
    }
}
