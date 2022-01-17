using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CChiTietSanPham
    {
        [Key]
        public String MaCTSP { get; set; }
        public CSanPham SanPham { get; set; }
        public String SanPhamMaSP { get; set; }
        public String Color { get; set; }
        public String GioTinh { get; set; }
        public String Size { get; set; }
        public String MoTaSP { get; set; }
        public String Anh { get; set; }
        public double DonGia { get; set; }
        public int SL { get; set; }
    }
}
