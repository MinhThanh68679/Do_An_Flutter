using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("Api/SP")]
    [ApiController]
    public class SanPhamsController : ControllerBase
    {
        private readonly ISanPham _sPService;

        public SanPhamsController(ISanPham SPService)
        {
            _sPService = SPService;
        }
        //Api/SP
        [HttpGet]
        public async Task<IActionResult> GetListSP()
        {
            try
            {
                var result = await _sPService.GetListSP();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Api/SP/Id?Id=??
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSPById(String Id)
        {
            try
            {
                var result = await _sPService.GetSpById(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Api/SP/search?color=??
        [HttpGet("Search")]
        public async Task<IActionResult> GetListSP_W_Color(String name,String color, String size, double price)
        {
            try
            {
                if(!String.IsNullOrEmpty(name))
                {
                    var result = await _sPService.Get_W_Name(name);
                    return Ok(result);
                }if(!String.IsNullOrEmpty(color))
                {
                    var result = await _sPService.Get_W_Color(color);
                    return Ok(result);
                }
                if(!String.IsNullOrEmpty(size))
                {
                    var result = await _sPService.Get_W_Size(size);
                    return Ok(result);
                }
                if (!Double.IsNaN(price))
                {
                    var result = await _sPService.Get_W_Price(price);
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
