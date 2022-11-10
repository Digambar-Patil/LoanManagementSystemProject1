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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AdminModel>().HasIndex(u => u.EmailAddress).IsUnique();
            base.OnModelCreating(builder);
            builder.Entity<UserModel>().HasIndex(u => u.EmailAddress).IsUnique();
        }


        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AdminModel> AdminModels { get; set; }
        public DbSet<LoanModel> LoanModels { get; set; }
        public DbSet<LoanMaster> LoanMasters { get; set; }
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<AdminModel> AdminInfo { get; set; }
    }


}
