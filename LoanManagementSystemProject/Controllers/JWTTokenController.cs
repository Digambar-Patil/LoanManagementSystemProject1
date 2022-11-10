using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly LMSDbContext _context;
        public JWTTokenController(IConfiguration configuration, LMSDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken(UserModel user)
        {
            if (user != null && user.EmailAddress != null && user.Password != null)
            {
                var userData = await GetUserInfo(user.EmailAddress, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (user != null)
                {
                    var claims = new[]
                    {
                         new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Id",user.CustomerId.ToString()),
                         new Claim("EmailAddress", user.EmailAddress),
                         new Claim("Password", user.Password)
                     };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("-->Incorrect Credentials--");
                }
            }
            else
            {
                return BadRequest("-->Incorrect Credentials--");
            }
        }

        [HttpGet]
        public async Task<UserModel> GetUserInfo(string emailaddress, string password)
        {
            return await _context.UserInfo.FirstOrDefaultAsync(x => x.EmailAddress == emailaddress && x.Password == password);
        }

        [HttpPost("Admin")]
        public async Task<IActionResult> GenerateAdminToken(AdminModel admin)
        {
            if (admin != null && admin.EmailAddress != null && admin.Password != null)
            {
                var userData = await GetAdminInfo(admin.EmailAddress, admin.Password);
                var jwt = _configuration.GetSection("Jwt").Get<JwtAdmin>();
                if (admin != null)
                {
                    var claims = new[]
                    {
                         new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("Id",admin.AdminId.ToString()),
                         new Claim("EmailAddress", admin.EmailAddress),
                         new Claim("Password", admin.Password)
                     };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("-->Incorrect Credentials--");
                }
            }
            else
            {
                return BadRequest("-->Incorrect Credentials--");
            }
        }

        [HttpGet("Admin")]
        public async Task<AdminModel> GetAdminInfo(string emailaddress, string password)
        {
            return await _context.AdminInfo.FirstOrDefaultAsync(x => x.EmailAddress == emailaddress && x.Password == password);
        }

    }
}
