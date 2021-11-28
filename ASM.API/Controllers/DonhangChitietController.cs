using ASM.Share.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangChitietController : ControllerBase
    {
        private readonly IDonhangSvc _donhangSvc;
        private readonly IDonhangChitietSvc _donhangChitietSvc;

        public DonhangChitietController(IDonhangSvc donhangSvc, IDonhangChitietSvc donhangChitietSvc)
        {
            _donhangSvc = donhangSvc;
            _donhangChitietSvc = donhangChitietSvc;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donhang>>> GetDonhang([FromQuery] int id)
        {
            var donhang = await _donhangSvc.GetDonhangAsync(id);
            List<Donhang> list = new List<Donhang>();
            list.Add(donhang);
            return list;
        }
    }
}
