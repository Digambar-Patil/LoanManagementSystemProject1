using LoanManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public interface IUser
    {
        Task<int> Create(UserModel registerUser);

        Task<UserModel> Login(int id, string Password);

        Task<UserModel> UpdateUser(int id, UserModel user);

        Task<UserModel> DeleteUser(int id);
    }
}
