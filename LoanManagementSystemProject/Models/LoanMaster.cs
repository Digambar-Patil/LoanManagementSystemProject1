using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystemProject.Models
{
    public class LoanMaster
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Loan Number")]
        public int LoanNumber { get; set; }

        [Required]
        [Display(Name = "Loan Amount")]
        public int LoanAmount { get; set; }

        [Required]
        [Display(Name = "Property Address")]
        [StringLength(50)]
        public string PropertyAddress { get; set; }

        [Display(Name ="Date of Approval")]
        public DateTime DateOfApproval { get; set; }

        [Display(Name = "Loan Status")]
        public string LoanStatus { get; set; }

        [Required]
        public double Income { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }

        [Display(Name = "Loan ID")]
        public int LoanId { get; set; }

        [ForeignKey("CustomerId")]
        public UserModel users { get; set; }

        [ForeignKey("AdminId")]
        public AdminModel admins { get; set; }

        [ForeignKey("LoanId")]
        public LoanModel loans { get; set; }

    }
}
