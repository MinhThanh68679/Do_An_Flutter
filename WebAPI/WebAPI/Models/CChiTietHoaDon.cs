using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CChiTietHoaDon
    {
        [Key]
        public String HoaDonMaHD { get; set; }
        public CHoaDon HoaDon { get; set; }
        [Key]
        public String SanPhamMaSp { get; set; }
        public CSanPham SanPham { get; set; }
        public int SL { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
// List , List CartId
