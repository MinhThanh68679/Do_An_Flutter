using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CBinhLuan
    {
        [Key]
        public String SanPhamMaSP { get; set; }
        public CSanPham SanPham { get; set; }
        [Key]
        public String KhachHangMaKH { get; set; }
        public CKhachHang KhachHang { get; set; }
        public String NoiDung { get; set; }
        public DateTime Update_Date { get; set; }
        public DateTime Delete_Date { get; set; }
        public bool Status { get; set; }
    }
}
