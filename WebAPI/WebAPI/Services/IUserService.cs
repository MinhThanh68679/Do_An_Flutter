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
        Task<Mess_Response> Sign_Up(SignUp_Request user);
        Task<Mess_Response> Sign_In(Login_Request user);
        Task<Mess_Response> Update_User(CKhachHang update_user);
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

        public async Task<Mess_Response> Sign_In(Login_Request user)
        {
            var response = new Mess_Response();
            var result = await _context.KhachHangs.FirstOrDefaultAsync(u => u.Email == user.User);
            if (result != null)
            {
                if (user.Pass == result.Pass)
                {
                    response.Mess = "Success";
                    response.Do = "Sign in";
                }
                else
                {
                    response.Mess = "Pass don't correct";
                    response.Do = "Sign in";
                }
            }
            else
            {
                response.Mess = "Don't have account with email "+ user.User;
                response.Do = "Sign in";
            }
            return response;
        }

        public async Task<Mess_Response> Sign_Up(SignUp_Request user)
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
                Avatar = user.Avatar,
                Status = true,
            };
            var result = await _context.KhachHangs.AddAsync(newuser);
            await _context.SaveChangesAsync();
            var response = new Mess_Response { Mess = "Sucees", Do = "Sign Up"};
            return response;
        }

        public async Task<Mess_Response> Update_User(CKhachHang update_user)
        {
            var user = await _context.KhachHangs.FirstOrDefaultAsync(u => u.MaKH == update_user.MaKH);
            var response = new Mess_Response();
            if(user != null)
            {
                user.TenKH = update_user.TenKH;
                user.DiaChi = update_user.DiaChi;
                user.Email = update_user.Email;
                user.SDT = update_user.SDT;
                user.Pass = update_user.Pass;
                user.Avatar = update_user.Avatar;

                await _context.SaveChangesAsync();
                response.Mess = "Success";
                response.Do = "Update";
            }
            else
            {
                response.Mess = "Don't have user with this ID:" + update_user.MaKH;
                response.Do = "Update";
            }
            return response;
        }
    }
}
