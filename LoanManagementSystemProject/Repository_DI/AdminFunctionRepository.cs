using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public class AdminFunctionRepository:IAdminFunctions
    {
        private readonly LMSDbContext lms_DbContext;

        public AdminFunctionRepository(LMSDbContext lms_DbContext)
        {
            this.lms_DbContext = lms_DbContext;
        }

        public async Task<LoanMaster> ApproveOrRejectLoan(int loanNumber, string status)
        {
            var ar = await lms_DbContext.LoanMasters.Where(x => x.LoanNumber == loanNumber).FirstOrDefaultAsync();
            ar.LoanStatus = status;
            await lms_DbContext.SaveChangesAsync();
            return ar;
        }

        public async Task<List<LoanMaster>> DisplayAllLoans(int adminId)
        {
            var ar = await lms_DbContext.LoanMasters.ToListAsync();
            List<LoanMaster> loanList = new List<LoanMaster>();
            foreach (var loan in ar)
            {
                if (loan.AdminId == adminId)
                {
                    loanList.Add(loan);
                }
            }
            return loanList;
        }
    }
}
