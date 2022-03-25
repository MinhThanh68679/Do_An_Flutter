 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Request;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("Api/Customer")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _userService.GetList();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Register")] 
        public async Task<IActionResult> Sign_Up(SignUp_Request user)
        {
            try
            {
                var result = await _userService.Sign_Up(user);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Sign_In(Login_Request user)
        {
            try
            {
                var result = await _userService.Sign_In(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update_User(CKhachHang user)
        {
            try
            {
                var result = await _userService.Update_User(user);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
