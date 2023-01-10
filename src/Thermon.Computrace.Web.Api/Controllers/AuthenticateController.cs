using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Api.Models;

namespace Thermon.Computrace.Web.Api.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration _configuration;
        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Post([FromBody] AuthenticateDto _userData)
        {
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                var user = new UserInfo();// await GetUser(_userData.Email, _userData.Password);
                if (string.IsNullOrEmpty(_userData.UserName) || string.IsNullOrEmpty(_userData.Password) || _userData.UserName != "demo" || _userData.Password != "123456")
                {
                    return null;
                }
                else
                {
                    user = new UserInfo()
                    {
                        UserName = _userData.UserName,
                        Password = _userData.Password,
                        Email = "test@demo.com",
                        DisplayName = "test demo",
                        UserId = 1
                    };
                }

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    user.Token = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}