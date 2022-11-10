using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public class UserFunctionRepository : IUserFunctions
    {
        readonly LMSDbContext lms_DbContext = null;
        public UserFunctionRepository(LMSDbContext lms_DbContext)
        {
            this.lms_DbContext = lms_DbContext;
        }
        public async Task<LoanMaster> ApplyLoan(int userId, int loanId, int income, int LoanAmout, string PropertyAddress)
        {
            LoanMaster addLoan = new LoanMaster();
            addLoan.CustomerId = userId;
            addLoan.LoanAmount = LoanAmout;
            addLoan.PropertyAddress = PropertyAddress;
            addLoan.DateOfApproval = DateTime.Now;
            addLoan.LoanStatus = "Applied";
            addLoan.Income = income;
            addLoan.LoanId = loanId;
            addLoan.AdminId = loanId;

            lms_DbContext.LoanMasters.Add(addLoan);
            await lms_DbContext.SaveChangesAsync();
            return addLoan;
        }

        public async Task<List<LoanModel>> DisplayLoanTypes()
        {
            var ar = await lms_DbContext.LoanModels.ToListAsync();
            return ar;
        }

        public async Task<List<LoanMaster>> GetLoanStatus(int customerid)
        {
            //var ar = await lMSDbContext.LoanMasters.Where(x => x.LoanNumber == id).FirstOrDefaultAsync();
            var ar = await lms_DbContext.LoanMasters.ToListAsync();
            List<LoanMaster> loans = new List<LoanMaster>();
            foreach (LoanMaster loan in ar)
            {
                if (loan.CustomerId == customerid)
                {
                    loans.Add(loan);
                }
            }
            return loans;
        }
    }
}
