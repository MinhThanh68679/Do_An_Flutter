using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Request;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("Api")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ICartService _service;

        public BillController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("Bill")]
        public async Task<IActionResult> GetList_Bill()
        {
            try
            {
                var result = await _service.GetList_Bill();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddBill")]
        public async Task<IActionResult> AddBill( AddBill_request requests)
        {
            try
            {
                var result = await _service.BuySP(requests);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddListBill")]
        public async Task<IActionResult> AddListBill(AddListBill_request request)
        {
            try
            {
                var result = await _service.AddBill(request);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Bill/{Id}")]
        public async Task<IActionResult> GetList_Bill_ByIdUser(String Id)
        {
            try
            {
                var result = await _service.GetList_Bill_ByIdUser(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("BillDetail")]
        public async Task<IActionResult> GetList_BillDetail()
        {
            try
            {
                var result = await _service.GetList_BillDetail();
                return Ok(result);            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("BillDetail/{Id}")]
        public async Task<IActionResult> GetList_BillDetail_ByBillId(String Id)
        {
            try
            {
                var result = await _service.GetList_BillDetail_ByBillId(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Cart")]
        public async Task<IActionResult> GetList_Cart()
        {
            try
            {
                var result = await _service.GetList_Cart();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("Cart/{Id}")]
        public async Task<IActionResult> GetList_Cart_ByIdUser(String Id)
        {
            try
            {
                var result = await _service.GetList_Cart_ByIdUser(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddCart")]
        public async Task<IActionResult> AddItemCart(AddCart_request request)
        {
            try
            {
                var result = await _service.AddCart(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
