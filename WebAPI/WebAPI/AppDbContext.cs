using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<CSanPham> SanPhams { get; set; }
        public DbSet<CChiTietSanPham> ChiTietSanPhams { get; set; }
        public DbSet<CKhachHang> KhachHangs { get; set; }
        public DbSet<CHoaDon> HoaDons { get; set; }
        public DbSet<CChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<CGioHang> GioHangs { get; set; }
        public DbSet<CBinhLuan> BinhLuans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CChiTietHoaDon>().HasKey(table => new {
                table.HoaDonMaHD,
                table.SanPhamMaSp,
            });

            modelBuilder.Entity<CGioHang>().HasKey(table => new {
                table.SanPhamMaSP,
                table.KhachHangMaKH,
            });

            modelBuilder.Entity<CBinhLuan>().HasKey(table => new {
                table.SanPhamMaSP,
                table.KhachHangMaKH,
            });

            base.OnModelCreating(modelBuilder);
            //Seed CSanPHam
            modelBuilder.Entity<CSanPham>().HasData( new CSanPham {MaSp="SP_1", TenSP="Áo thun đi biển",LoaiSanPham="Áo",Update_Date=new DateTime(2021, 12, 18, 12, 1, 10), Delete_Date= new DateTime(2021, 12, 18, 12, 1, 10), Status=true  });
            modelBuilder.Entity<CSanPham>().HasData( new CSanPham {MaSp="SP_2", TenSP="quần bơi",LoaiSanPham="quần",Update_Date=new DateTime(2021, 12, 18, 12, 1, 10), Delete_Date= new DateTime(2021, 12, 18, 12, 1, 10), Status=true  });
            modelBuilder.Entity<CSanPham>().HasData( new CSanPham {MaSp="SP_3", TenSP="Áo thun tay dài",LoaiSanPham="Áo",Update_Date=new DateTime(2021, 12, 18, 12, 1, 10), Delete_Date= new DateTime(2021, 12, 18, 12, 1, 10), Status=true  });
            modelBuilder.Entity<CSanPham>().HasData( new CSanPham {MaSp="SP_4", TenSP="Áo thun tay ngắn",LoaiSanPham="Áo",Update_Date=new DateTime(2021, 12, 18, 12, 1, 10), Delete_Date= new DateTime(2021, 12, 18, 12, 1, 10), Status=true  });
            //Seed CChiTietSanPham
            modelBuilder.Entity<CChiTietSanPham>().HasData(new CChiTietSanPham { MaCTSP= "CTSP_01", SanPhamMaSP= "SP_1", Color="Trắng, Xanh, Vàng", GioTinh="Nam", Size="M,X,XL", MoTaSP="",Anh="",DonGia=30,SL=10 });
            modelBuilder.Entity<CChiTietSanPham>().HasData(new CChiTietSanPham { MaCTSP= "CTSP_02", SanPhamMaSP= "SP_2", Color="Đen, Xanh", GioTinh="Nam", Size="M,X", MoTaSP="",Anh="",DonGia=30,SL=10 });
            modelBuilder.Entity<CChiTietSanPham>().HasData(new CChiTietSanPham { MaCTSP= "CTSP_03", SanPhamMaSP= "SP_3", Color="Xám, Đen, Vàng, Lục", GioTinh="Nữ", Size="S,M", MoTaSP="",Anh="",DonGia=30,SL=10 });
            modelBuilder.Entity<CChiTietSanPham>().HasData(new CChiTietSanPham { MaCTSP= "CTSP_04", SanPhamMaSP= "SP_4", Color= "Trắng, Đen, Đỏ, Xanh", GioTinh="UniSex", Size="S,M,X", MoTaSP="",Anh="",DonGia=30,SL=10 });
            //Seed CKhachHang
            modelBuilder.Entity<CKhachHang>().HasData(new CKhachHang { MaKH = "Admin_1", TenKH = "Toàn", SDT = "0306181281", DiaChi = "CKC", Email = "0306181281@CaoThang.edu.vn", Pass = "81PT", Avatar = "", Status = true });
            modelBuilder.Entity<CKhachHang>().HasData(new CKhachHang { MaKH = "Admin_2", TenKH = "Thành", SDT = "0306181363", DiaChi = "CKC", Email = "0306181363@CaoThang.edu.vn", Pass = "63MT", Avatar = "", Status = true });
            modelBuilder.Entity<CKhachHang>().HasData(new CKhachHang { MaKH = "Admin_3", TenKH = "Duyên", SDT = "0306181209", DiaChi = "CKC", Email = "0306181209@CaoThang.edu.vn", Pass = "09ND", Avatar = "", Status = true });
            //Seed CHoaDon
            modelBuilder.Entity<CHoaDon>().HasData(new CHoaDon { MaHD = "HD01", KhachHangMaKH = "Admin_1", NgayGiao = new DateTime(2022, 1, 10), GhiChu = "Note about alternative recipient,", TongTien = 30, Update_Date = new DateTime(2021, 12, 28), Delete_Date = new DateTime(2021, 12, 28), Status = 1 });
            modelBuilder.Entity<CHoaDon>().HasData(new CHoaDon { MaHD = "HD02", KhachHangMaKH = "Admin_1", NgayGiao = new DateTime(2022, 1, 28), GhiChu = "Note about alternative recipient", TongTien = 60, Update_Date = new DateTime(2021, 12, 28), Delete_Date = new DateTime(2021, 12, 28), Status = 1 });
            modelBuilder.Entity<CHoaDon>().HasData(new CHoaDon { MaHD = "HD03", KhachHangMaKH = "Admin_2", NgayGiao = new DateTime(2022, 1, 28), GhiChu = "Note about alternative recipient", TongTien = 60, Update_Date = new DateTime(2021, 12, 28), Delete_Date = new DateTime(2021, 12, 28), Status = 1 });
            //Seed CChiTietHoaDon
            modelBuilder.Entity<CChiTietHoaDon>().HasData(new CChiTietHoaDon { HoaDonMaHD = "HD01", SanPhamMaSp = "SP_1", SL=1,DonGia=30,ThanhTien=30});
            modelBuilder.Entity<CChiTietHoaDon>().HasData(new CChiTietHoaDon { HoaDonMaHD = "HD02", SanPhamMaSp = "SP_2", SL =1,DonGia=30,ThanhTien=30});
            modelBuilder.Entity<CChiTietHoaDon>().HasData(new CChiTietHoaDon { HoaDonMaHD = "HD02", SanPhamMaSp = "SP_3", SL =1,DonGia=30,ThanhTien=30});
            modelBuilder.Entity<CChiTietHoaDon>().HasData(new CChiTietHoaDon { HoaDonMaHD = "HD03", SanPhamMaSp = "SP_4", SL =2,DonGia=30,ThanhTien=60});
            //Seed CGioHang
            modelBuilder.Entity<CGioHang>().HasData(new CGioHang { KhachHangMaKH = "Admin_1", SanPhamMaSP ="SP_4", Update_Date = new DateTime(2022, 1, 1), Status= true });
            modelBuilder.Entity<CGioHang>().HasData(new CGioHang { KhachHangMaKH = "Admin_3", SanPhamMaSP ="SP_1", Update_Date = new DateTime(2022, 1, 1), Status= true });
            modelBuilder.Entity<CGioHang>().HasData(new CGioHang { KhachHangMaKH = "Admin_3", SanPhamMaSP ="SP_2", Update_Date = new DateTime(2022, 1, 1), Status= true });
            //Seed CBinhLuan
        }
    }
}
