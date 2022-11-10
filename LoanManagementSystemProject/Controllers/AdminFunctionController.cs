using LoanManagementSystemProject.Models;
using LoanManagementSystemProject.Repository_DI;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AdminFunctionController : ControllerBase
    {
        private readonly IAdminFunctions adminFunctions;

        public AdminFunctionController(IAdminFunctions adminFunctions)
        {
            this.adminFunctions = adminFunctions;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAllAppliedLoans(int adminId)
        {
            var ar =  await adminFunctions.DisplayAllLoans(adminId);
            if(ar != null)
            {
                return Ok(ar);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ApproveLoan(int adminId, int loanNumber, string status)
        {
            var ar = await adminFunctions.ApproveOrRejectLoan(adminId, loanNumber, status);
            if(ar != null) { 
                return Ok(ar);
            }
            else
            {
                return NotFound(ar);
            }
        }

        [HttpPost("RegisterLoan")]
        public async Task<IActionResult> RegisterLoan(LoanModel regloan)
        {
            var ar = await adminFunctions.RegisterLoan(regloan);
            return Ok(ar);
        }

        [HttpDelete("DeleteLoan")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var ar = await adminFunctions.DeleteLoan(id);
            return Ok(ar);
        }


    }
}
