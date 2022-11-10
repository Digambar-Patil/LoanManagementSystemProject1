﻿// <auto-generated />
using System;
using LoanManagementSystemProject.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanManagementSystemProject.Migrations
{
    [DbContext(typeof(LMSDbContext))]
    partial class LMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LoanManagementSystemProject.Models.AdminModel", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("AdminId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("AdminModel");
                });

            modelBuilder.Entity("LoanManagementSystemProject.Models.LoanMaster", b =>
                {
                    b.Property<int>("LoanNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfApproval")
                        .HasColumnType("datetime2");

                    b.Property<double>("Income")
                        .HasColumnType("float");

                    b.Property<int>("LoanAmount")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<string>("LoanStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoanNumber");

                    b.HasIndex("AdminId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanMasters");
                });

            modelBuilder.Entity("LoanManagementSystemProject.Models.LoanModel", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<string>("LoanType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxTenure")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("LoanModels");
                });

            modelBuilder.Entity("LoanManagementSystemProject.Models.UserModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Income")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("LoanManagementSystemProject.Models.LoanMaster", b =>
                {
                    b.HasOne("LoanManagementSystemProject.Models.AdminModel", "admins")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystemProject.Models.UserModel", "users")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystemProject.Models.LoanModel", "loans")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admins");

                    b.Navigation("loans");

                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
