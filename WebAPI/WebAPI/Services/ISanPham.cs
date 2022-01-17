using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Response;

namespace WebAPI.Services
{
    public interface ISanPham
    {
        Task<List<CChiTietSanPham>> GetListSP();
        Task<CChiTietSanPham> GetSpById(String Id);
        Task<SP_Response> Get_W_Size(String Size);
        Task<SP_Response> Get_W_Color(String Color);
        Task<SP_Response> Get_W_Price(double Price);
        Task<SP_Response> Get_W_Name(String Name);
    }

    public class SanPhamService : ISanPham
    {
        private readonly AppDbContext _contetxt;

        public SanPhamService(AppDbContext contetxt)
        {
            _contetxt = contetxt;
        }

        public async Task<List<CChiTietSanPham>> GetListSP()
        {
            var result = await _contetxt.ChiTietSanPhams.Include(s => s.SanPham).ToListAsync();
            return result;
        }

        public async Task<CChiTietSanPham> GetSpById(string Id)
        {
            //var result = await _contetxt.ChiTietSanPhams.Include(s=>s.SanPham).FirstOrDefaultAsync(p => p.MaCTSP == Id);
            var result = await _contetxt.ChiTietSanPhams.FirstOrDefaultAsync(p => p.MaCTSP == Id);
            return result;
        }

        public async Task<SP_Response> Get_W_Color(string Color)
        {
            var response = new SP_Response();
            var result = await _contetxt.ChiTietSanPhams.Include(s => s.SanPham).Where(c => c.Color.Contains(Color)).ToListAsync();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(Color))
                {
                    response.SanPhams = result;
                    response.Mess = "Succes";
                }
            }
            else
            {
                response.SanPhams = null;
                response.Mess = "Fail";
            }
            return response;

        }

        public async Task<SP_Response> Get_W_Name(string Name)
        {
            var response = new SP_Response();
            var result = await _contetxt.ChiTietSanPhams.Include(s => s.SanPham).Where(c => c.SanPham.TenSP.Contains(Name)).ToListAsync();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    response.SanPhams = result;
                    response.Mess = "Succes";
                }
            }
            else
            {
                response.SanPhams = null;
                response.Mess = "Fail";
            }
            return response;
        }

        public async Task<SP_Response> Get_W_Price(double Price)
        {
            var response = new SP_Response();
            var result = await _contetxt.ChiTietSanPhams.Include(s => s.SanPham).Where(c => c.DonGia <= Price).ToListAsync();
            if (result != null)
            {
                if (!Double.IsNaN(Price))
                {
                    response.SanPhams = result;
                    response.Mess = "Succes";
                }
            }
            else
            {
                response.SanPhams = null;
                response.Mess = "Fail";
            }
            return response;
        }

        public async Task<SP_Response> Get_W_Size(string Size)
        {
            var response = new SP_Response();
            var result = await _contetxt.ChiTietSanPhams.Include(s => s.SanPham).Where(c => c.Size.Contains(Size)).ToListAsync();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(Size))
                {
                    response.Mess = "Succes";
                    response.SanPhams = result;
                }
            }
            else
            {
                response.Mess = "Fail";
                response.SanPhams = null;
            }
            return response;
        }
    }
}
