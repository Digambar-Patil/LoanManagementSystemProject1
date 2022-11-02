using LoanManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IUserFunctions
    {
        //Task<LoanMaster> ApplyLoan(UserModel userInfo, LoanModel loanInfo, AdminModel adminInfo, int LoanAmout, string PropertyAddress);
        Task<LoanMaster> ApplyLoan(int userId, int loanId, int adminId, int income, int LoanAmout, string PropertyAddress);
        Task<List<LoanModel>> DisplayLoanTypes();
        Task<LoanMaster> GetLoanStatus(int id);
    }
}
