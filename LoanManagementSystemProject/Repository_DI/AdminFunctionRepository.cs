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

        public async Task<LoanMaster> ApproveOrRejectLoan(int adminId, int loanNumber, string status)
        {
            var ar = await lms_DbContext.LoanMasters.Where(x => x.LoanNumber == loanNumber && x.AdminId == adminId).FirstOrDefaultAsync();
            if(ar != null) {
                ar.LoanStatus = status;
                await lms_DbContext.SaveChangesAsync();
                return ar;
            }
            else
            {
                return null;
            }
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

        public async Task<LoanModel> RegisterLoan(LoanModel regloan)
        {
            lms_DbContext.Add(regloan);
            await lms_DbContext.SaveChangesAsync();
            return regloan;
        }

        public async Task<LoanModel> DeleteLoan(int id)
        {
            var ar = await lms_DbContext.LoanModels.Where(x => x.LoanId == id).FirstOrDefaultAsync();
            if (ar != null)
            {
                lms_DbContext.Remove(ar);
                await lms_DbContext.SaveChangesAsync();
            }
            return ar;
        }
    }
}
