using LinkClip.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Domain.Models.Account
{
    public class User : BaseEntity
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200,ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Mobile { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string LastName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Password { get; set; }
        [Display(Name = "Active or InActive")]
        public bool IsMobileActive { get; set; }
        [Display(Name = "Blocked / Not Blocked")]
        public bool IsBlocked { get; set; }

        [Display(Name = "Admin / Not Admin")]
        public bool IsAdmin { get; set; }
    }
}
