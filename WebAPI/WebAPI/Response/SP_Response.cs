using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Response
{
    public class SP_Response
    {
        public List<CChiTietSanPham> SanPhams { get; set; }
        public String Mess { get; set; }
    }
}
