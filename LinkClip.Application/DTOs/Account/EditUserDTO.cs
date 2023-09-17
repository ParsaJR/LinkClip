using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Application.DTOs.Account
{
    public class EditUserDTO
    {
        public long UserId { get; set; }
        [Display(Name = "PhoneNumber")]

        public string Mobile { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string LastName { get; set; }
        [Display(Name = "Blocked / Not Blocked")]
        public bool IsBlocked { get; set; }

        [Display(Name = "Admin / Not Admin")]
        public bool IsAdmin { get; set; }
    }
    public enum EditUserResult
    {
        NotFound,
        Success
    }
}
