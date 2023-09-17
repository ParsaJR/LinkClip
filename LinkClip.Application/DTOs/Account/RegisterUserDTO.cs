
using System.ComponentModel.DataAnnotations;


namespace LinkClip.Application.DTOs.Account
{
    public class RegisterUserDTO
    {
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
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
        [Display(Name = "RepeatPassword")]
        [Required(ErrorMessage = "Please Enter {0} field")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        [Compare("Password",ErrorMessage = "The passwords are not match")]
        public string RepeatPassword { get; set; }
    }
    public enum RegisterUserResult
    {
        IsMobileExist,
        Success
        
    } 
}
