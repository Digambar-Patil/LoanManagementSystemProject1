using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystemProject.Models
{
    public class LoanModel
    {
        [Required]
        [Key]
        [Display(Name = "Loan ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }

        [Required]
        [Display(Name = "Loan Type")]
        public string LoanType { get; set; }

        [Required]
        [Display(Name = "Interest Rate per Annum")]
        public double InterestRate { get; set; }

        [Required]
        [Display(Name = "Maximum Number of Months")]
        public int MaxTenure { get; set; }

    }
}
