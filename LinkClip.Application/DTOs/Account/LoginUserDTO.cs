using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkClip.Application.DTOs.Account
{
    public class LoginUserDTO
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Mobile { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
    public enum loginUserResult
    {
        NotFound,
        NotActived,
        Success
    }
}
