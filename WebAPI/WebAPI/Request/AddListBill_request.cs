using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Request
{
    public class AddListBill_request
    {
        public String MaKH { get; set; }
        public List<ListBill> Products { get; set; }
    }

    public class ListBill
    {
        public String MaSP { get; set; }
        public int Sl { get; set; }
    }
}
