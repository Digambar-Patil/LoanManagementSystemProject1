using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystemProject.Models;

namespace LoanManagementSystemProject.DataAccessLayer
{
    public class LMSDbContext:DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AdminModel> AdminModels { get; set; }
        public DbSet<LoanModel> LoanModels { get; set; }
        public DbSet<LoanMaster> LoanMasters { get; set; }
    }


}
