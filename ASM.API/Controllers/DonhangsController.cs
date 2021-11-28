using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASM.Share.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangController : ControllerBase
    {
        private readonly IDonhangSvc _donhangSvc;

        public DonhangController(IDonhangSvc donhangSvc)
        {
            _donhangSvc = donhangSvc;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donhang>>> GetDonhangbyKhachhang([FromQuery]int id)
        {
            var listDonhang = await _donhangSvc.GetDonhangbyKhachhangAsync(id);
            return listDonhang;
        }
    }
}
