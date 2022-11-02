using LoanManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IAdmin
    {
        Task<int> Create(AdminModel registerUser);

        Task<AdminModel> Login(int id, string Password);

        Task<AdminModel> UpdateAdmin(int id, AdminModel user);

        Task<AdminModel> DeleteAdmin(int id);

        Task<List<AdminModel>> ShowAllAdmin();
    }
}
