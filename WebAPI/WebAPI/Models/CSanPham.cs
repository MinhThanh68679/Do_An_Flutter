using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CSanPham
    {

        [Key]
        public String MaSp { get; set; }
        public String TenSP { get; set; }
        public String LoaiSanPham { get; set; }
        public DateTime Update_Date { get; set; }
        public DateTime Delete_Date { get; set; }
        public bool Status { get; set; }
    }
}
//API DanhSachSanPham, TK Gia, TK Color, TK Size, TK Id
