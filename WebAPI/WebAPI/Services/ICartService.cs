using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Request;

namespace WebAPI.Services
{
    public interface ICartService
    {
        //CHoaDOn
        Task<CHoaDon> BuySP(AddBill_request request);
        Task<IEnumerable<CHoaDon>> GetList_Bill();
        Task<IEnumerable<CHoaDon>> GetList_Bill_ByIdUser(String Id);
        //CChiTietHoaDon
        Task<IEnumerable<CChiTietHoaDon>> GetList_BillDetail();
        Task<IEnumerable<CChiTietHoaDon>> GetList_BillDetail_ByBillId(String Id);
        //GioHang
        Task<IEnumerable<CGioHang>> GetList_Cart();
        Task<IEnumerable<CGioHang>> GetList_Cart_ByIdUser(String Id);

    }

    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CHoaDon>> GetList_Bill()
        {
            var result =  await _context.HoaDons.Include(c=>c.KhachHang).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CHoaDon>> GetList_Bill_ByIdUser(string Id)
        {
            var result = await _context.HoaDons.Where(u=>u.KhachHangMaKH==Id).Include(c => c.KhachHang).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CChiTietHoaDon>> GetList_BillDetail()
        {
            var result = await _context.ChiTietHoaDons.Include(c=>c.SanPham).Include(c=>c.HoaDon).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CChiTietHoaDon>> GetList_BillDetail_ByBillId(string Id)
        {
            var result = await _context.ChiTietHoaDons.Where(c=>c.HoaDonMaHD == Id).Include(c => c.HoaDon).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CGioHang>> GetList_Cart()
        {
            var result = await _context.GioHangs.Include(c=>c.SanPham).Include(c=>c.KhachHang).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CGioHang>> GetList_Cart_ByIdUser(String Id)
        {
            var result = await _context.GioHangs.Where(c=>c.KhachHangMaKH==Id).Include(c => c.SanPham).Include(c => c.KhachHang).ToListAsync();
            return result;
        }

        public async Task<CHoaDon> BuySP(AddBill_request request)
        {
            int count = _context.HoaDons.Count();
            var newBill = new CHoaDon
            {
                MaHD = "HD" + count.ToString(),
                KhachHangMaKH = request.MaKH,
            };
            await _context.HoaDons.AddAsync(newBill);
            await _context.SaveChangesAsync();

            var newBillDetail = new CChiTietHoaDon();
            newBillDetail.SanPhamMaSp = request.MaSP;
            newBillDetail.SL = request.SL;
            newBillDetail.HoaDonMaHD = newBill.MaHD;
            await _context.ChiTietHoaDons.AddAsync(newBillDetail);
            await _context.SaveChangesAsync();
            return newBill;
        }
    }
}
