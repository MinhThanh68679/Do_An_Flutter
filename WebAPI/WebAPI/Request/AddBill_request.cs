﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Request
{
    public class AddBill_request
    {
        public String MaKH { get; set; }
        public String MaSP { get; set; }
        public int Sl { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}
