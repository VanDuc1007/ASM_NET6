using ASM.Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // GET: api/<TokenController>
        public IKhachhangSvc _khachhangSvc;
        public IConfiguration _configuration;

        public TokenController(IConfiguration configuration, IKhachhangSvc khachhangSvc)
        {
            _khachhangSvc = khachhangSvc;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ViewWebLogin viewWebLogin)
        {
            
            if (viewWebLogin != null &&! string.IsNullOrEmpty(viewWebLogin.Email)&& !string.IsNullOrEmpty(viewWebLogin.Password))
            {
                var khachhang = _khachhangSvc.LoginAsync(viewWebLogin);
                if (khachhang != null)
                {
                    if (khachhang != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] 
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", khachhang.KhachhangID.ToString()),
                            new Claim("FullName", khachhang.FullName),
                            new Claim("Email", khachhang.EmailAddress),
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                            claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                        ViewToken viewToken = new ViewToken() 
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token), 
                            KhachhangId =khachhang.KhachhangID 
                            
                        };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                else
                {
                   
                    return BadRequest();
                }
            }
            
            return BadRequest();
        }      
    }
}
