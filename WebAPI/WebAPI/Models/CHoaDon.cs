using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CHoaDon
    {
        [Key]
        public String MaHD { get; set; }
        public CKhachHang KhachHang { get; set; }
        public String KhachHangMaKH { get; set; }
        public DateTime NgayGiao { get; set; }
        public String GhiChu { get; set; }
        public double TongTien { get; set; }
        public DateTime Update_Date { get; set; }
        public DateTime Delete_Date { get; set; }
        public int Status { get; set; }
    }
}
//API List, List User, 