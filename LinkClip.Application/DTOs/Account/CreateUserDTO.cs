
using System.ComponentModel.DataAnnotations;


namespace LinkClip.Application.DTOs.Account
{
    public class CreateUserDTO
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

        [Display(Name = "Admin / Not Admin")]
        public bool IsAdmin { get; set; }
    }
    public enum CreateUserResult
    {
         Success,
        IsMobileExist
    }
}
