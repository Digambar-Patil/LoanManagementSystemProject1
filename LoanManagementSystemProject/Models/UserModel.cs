using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystemProject.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Customer ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(13)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        public double Income { get; set; }

    }


    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
