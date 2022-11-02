using LoanManagementSystemProject.Models;
using LoanManagementSystemProject.Repository_DI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user = null;

        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserModel registerUser)
        {
            var query = await user.Create(registerUser);
            return Ok(query);
        }

        [HttpGet("{id},{Password}")]
        public async Task<IActionResult> Login(int id, string Password)
        {
            var query = await user?.Login(id, Password);
            return Ok(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UserModel editUser)
        {
            var ar1 = await user.UpdateUser(id, editUser);
            return Ok(ar1);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ar1 = await user.DeleteUser(id);
            return Ok(ar1);
        }
    }
}
