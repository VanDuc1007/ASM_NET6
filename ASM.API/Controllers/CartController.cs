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
    public class CartController : ControllerBase
    {
        private readonly IDonhangSvc _donhangSvc;
        private readonly IDonhangChitietSvc _donhangChitietSvc;

        public CartController(IDonhangSvc donhangSvc, IDonhangChitietSvc donhangChitietSvc)
        {
            _donhangSvc = donhangSvc;
            _donhangChitietSvc = donhangChitietSvc;           
        }
        //Post api/Donhang
        [HttpPost]
        public async Task<ActionResult<int>> PostCart (Cart giohang)
        {
            try
            {
                var donhang = new Donhang()
                {
                    TrangthaiDonhang = TrangthaiDonhang.Moidat,
                    KhachhangID = giohang.KhachhangId,
                    Tongtien = giohang.Tongtien,
                    Ngaydat = DateTime.Now,
                    Ghichu ="",
                };
                int donhangID = await _donhangSvc.AddDonhangAsync(donhang);
                donhang.DonhangID = donhangID;
                List<CartItem> dataCart = giohang.ListViewCart;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    DonhangChitiet chitiet = new DonhangChitiet()
                    {
                        DonhangID = donhangID,
                        MonAnID = dataCart[i].MonAn.MonAnID,
                        Soluong = dataCart[i].Quantity,
                        Thanhtien = dataCart[i].MonAn.Gia * dataCart[i].Quantity,
                        Ghichu = "",
                    };
                    _donhangChitietSvc.AddDonhangChitietSvc(chitiet);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
