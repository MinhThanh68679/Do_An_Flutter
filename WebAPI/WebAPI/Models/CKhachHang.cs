using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CKhachHang
    {
        [Key]
        public String MaKH { get; set; }
        public String TenKH { get; set; }
        public String DiaChi { get; set; }
        public String Email { get; set; }
        public String SDT { get; set; }
        public String Pass { get; set; }
        public String Avatar { get; set; }
        public bool Status { get; set; }
    }
}
//API DanhSach,DangNhap, DangKy, Update_User