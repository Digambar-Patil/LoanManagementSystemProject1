using LoanManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystemProject.DataAccessLayer;

namespace LoanManagementSystemProject.Repository_DI
{
    public class UserRepository : IUser
    {
        readonly LMSDbContext lms_DbContext = null;
        public UserRepository(LMSDbContext lms_DbContext)
        {
            this.lms_DbContext = lms_DbContext;
        }

        public async Task<int> Create(UserModel registerUser)
        {
            lms_DbContext.UserModels.Add(registerUser);
            await lms_DbContext.SaveChangesAsync();
            return registerUser.CustomerId;
        }


        public async Task<UserModel> Login(int id,string Password)
        {
            var ar = await lms_DbContext.UserModels.Where(x => x.CustomerId == id && x.Password == Password).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<UserModel> UpdateUser(int id, UserModel user)
        {
            var ar = await lms_DbContext.UserModels.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            if(ar != null)
            {
                ar.Name = user.Name;
                ar.Password = user.Password;
                ar.ConfirmPassword = user.ConfirmPassword;
                ar.Address = user.Address;
                ar.EmailAddress = user.EmailAddress;
                ar.State = user.State;
                ar.Country = user.Country;
            }
            await lms_DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var ar = await lms_DbContext.UserModels.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            if(ar != null)
            {
                lms_DbContext.Remove(ar);
                await lms_DbContext.SaveChangesAsync();
            }
            return ar;
        }
    }
}
