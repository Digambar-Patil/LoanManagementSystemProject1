using LoanManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IAdminFunctions
    {
        Task<List<LoanMaster>> DisplayAllLoans(int adminId);
        Task<LoanMaster> ApproveOrRejectLoan(int loanNumber, string status);

    }
}
