using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASM.Share.Models;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonAnController : ControllerBase
    {

        private readonly IMonAnSvc _monanSvc;

        public MonAnController(IMonAnSvc monanSvc)
        {
            _monanSvc = monanSvc;
        }

        // GET: api/MonAns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonAn>>> GetMonAn()
        {
            return await _monanSvc.GetMonAnAllAsync();
        }
    }
}
