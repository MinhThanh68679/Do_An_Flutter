using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class AddTable_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "MaKH", "Avatar", "DiaChi", "Email", "Pass", "SDT", "Status", "TenKH" },
                values: new object[,]
                {
                    { "Admin_1", "", "CKC", "0306181281@CaoThang.edu.vn", "81PT", "0306181281", true, "Toàn" },
                    { "Admin_2", "", "CKC", "0306181363@CaoThang.edu.vn", "63MT", "0306181363", true, "Thành" },
                    { "Admin_3", "", "CKC", "0306181209@CaoThang.edu.vn", "09ND", "0306181209", true, "Duyên" }
                });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_1",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_2",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_3",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_4",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 18, 12, 1, 10, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_1",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 19, 0, 22, 810, DateTimeKind.Local).AddTicks(1169), new DateTime(2021, 12, 18, 19, 0, 22, 808, DateTimeKind.Local).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_2",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9651), new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_3",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9834), new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "MaSp",
                keyValue: "SP_4",
                columns: new[] { "Delete_Date", "Update_Date" },
                values: new object[] { new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9874), new DateTime(2021, 12, 18, 19, 0, 22, 811, DateTimeKind.Local).AddTicks(9871) });
        }
    }
}
