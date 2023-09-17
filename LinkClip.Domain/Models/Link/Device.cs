

using LinkClip.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LinkClip.Domain.Models.Link
{
    public class Device : BaseEntity
    {
        [Display(Name = "FullUrl")]
        public bool IsBot { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Brand { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Family { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Model { get; set; }

    }
}
