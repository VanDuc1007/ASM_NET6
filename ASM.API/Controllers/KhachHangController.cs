using ASM.Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachhangSvc _khachhangSvc;
        public KhachHangController(IKhachhangSvc khachhangSvc)
        {
            _khachhangSvc = khachhangSvc;
        }
        [HttpGet]
        public async Task<ActionResult<Khachhang>> GetKhachHang([FromQuery] int id)
        {
            Khachhang khachhang = await _khachhangSvc.GetKhachhangAsync(id);
            return khachhang;
        }
        
        [HttpPost]
        public async Task<ActionResult<Khachhang>> PostKhachhang(Khachhang khachhang)
        {
            try
            {
                int id = await _khachhangSvc.AddKhachhangAsync(khachhang);
                khachhang.KhachhangID = id;
            }
            catch(Exception ex)
            {

            }
            return Ok(1);
        }
    }
}
