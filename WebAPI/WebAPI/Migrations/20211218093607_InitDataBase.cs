using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSp);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhams",
                columns: table => new
                {
                    MaCTSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SanPhamMaSP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhams", x => x.MaCTSP);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_SanPhams_SanPhamMaSP",
                        column: x => x.SanPhamMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_SanPhamMaSP",
                table: "ChiTietSanPhams",
                column: "SanPhamMaSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietSanPhams");

            migrationBuilder.DropTable(
                name: "SanPhams");
        }
    }
}
