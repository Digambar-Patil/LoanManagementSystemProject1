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
        public async Task<IActionResult> ApproveLoan(int loanNumber, string status)
        {
            var ar = await adminFunctions.ApproveOrRejectLoan(loanNumber, status);
            return Ok(ar);
        }
    }
}
