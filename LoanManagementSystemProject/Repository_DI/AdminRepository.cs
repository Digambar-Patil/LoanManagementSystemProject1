using LoanManagementSystemProject.DataAccessLayer;
using LoanManagementSystemProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementSystemProject.Repository_DI
{
    public class AdminRepository : IAdmin
    {
        readonly LMSDbContext lms_DbContext = null;
        public AdminRepository(LMSDbContext lms_DbContext)
        {
            this.lms_DbContext = lms_DbContext;
        }
        public async Task<int> Create(AdminModel registerAdmin)
        {
            lms_DbContext.Add(registerAdmin);
            await lms_DbContext.SaveChangesAsync();
            return registerAdmin.AdminId;
        }

        public async Task<AdminModel> DeleteAdmin(int id)
        {
            var ar = await lms_DbContext.AdminModels.Where(x => x.AdminId == id).FirstOrDefaultAsync();
            if(ar != null)
            {
                lms_DbContext.Remove(ar);
                await lms_DbContext.SaveChangesAsync();
            }
            return ar;
        }

        public async Task<AdminModel> Login(int id, string Password)
        {
            var ar = await lms_DbContext.AdminModels.Where(x => x.AdminId == id && x.Password == Password).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<AdminModel> UpdateAdmin([FromRoute]int id,[FromBody] AdminModel admin)
        {
            var ar = await lms_DbContext.AdminModels.Where(x => x.AdminId == id).FirstOrDefaultAsync();
            if(ar != null)
            {
                ar.Name = admin.Name;
                ar.EmailAddress = admin.EmailAddress;
                ar.Password = admin.Password;
                ar.ConfirmPassword = admin.ConfirmPassword;              
            }
            await lms_DbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<List<AdminModel>> ShowAllAdmin()
        {
            var ar = await lms_DbContext.AdminModels.ToListAsync();
            List<AdminModel> adminList = new List<AdminModel>();
            foreach (var record in ar)
            {
               // adminList.Add(ar);
            }
            return ar;
        }
    }
}
