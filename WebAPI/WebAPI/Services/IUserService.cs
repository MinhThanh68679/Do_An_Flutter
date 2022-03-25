using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Request;
using WebAPI.Response;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<CKhachHang>> GetList();
        Task<CKhachHang> Sign_Up(SignUp_Request user);
        Task<CKhachHang> Sign_In(Login_Request user);
        Task<CKhachHang> Update_User(CKhachHang update_user);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CKhachHang>> GetList()
        {
            var result = await _context.KhachHangs.ToListAsync();
            return result;
        }

        public async Task<CKhachHang> Sign_In(Login_Request user)
        {
            var result = await _context.KhachHangs.FirstOrDefaultAsync(u => u.Email == user.User);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<CKhachHang> Sign_Up(SignUp_Request user)
        {
            int count = _context.KhachHangs.Count();
            var newuser = new CKhachHang
            {
                MaKH = "KH" + count.ToString(),
                TenKH = user.Name,
                DiaChi = user.Address,
                Email = user.Email,
                SDT = user.Phone,
                Pass = user.Pass,
                Avatar = "assets/images/profile_1.png",
                Status = true,
            };
            var result = await _context.KhachHangs.AddAsync(newuser);
            await _context.SaveChangesAsync();
            return newuser;
        }

        public async Task<CKhachHang> Update_User(CKhachHang update_user)
        {
            var user = await _context.KhachHangs.FirstOrDefaultAsync(u => u.MaKH == update_user.MaKH);
            if(user != null)
            {
                user.TenKH = update_user.TenKH;
                user.Email = update_user.Email;
                user.SDT = update_user.SDT;
                await _context.SaveChangesAsync();
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
