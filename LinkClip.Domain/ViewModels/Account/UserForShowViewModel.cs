
using System.ComponentModel.DataAnnotations;


namespace LinkClip.Domain.ViewModels.Account
{
    public class UserForShowViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "PhoneNumber")]

        public string Mobile { get; set; }
        [Display(Name = "FirstName")]

        public string FirstName { get; set; }
        [Display(Name = "LastName")]

        public string LastName { get; set; }
        [Display(Name = "Blocked / Not Blocked")]
        public bool IsBlocked { get; set; }

        [Display(Name = "Admin / Not Admin")]
        public bool IsAdmin { get; set; }
    }
}
