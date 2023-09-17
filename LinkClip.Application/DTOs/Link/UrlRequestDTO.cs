using System.ComponentModel.DataAnnotations;

namespace LinkClip.Application.DTOs.Link
{
    public class UrlRequestDTO
    {
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string OriginalUrl { get; set; }
    }

    public enum UrlRequestResult
    {
        Success,
        Error
    }
}
