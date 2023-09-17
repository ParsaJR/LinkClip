
using LinkClip.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LinkClip.Domain.Models.Link
{
    public class OS : BaseEntity
    {
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Family { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Major { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Minor { get; set; }
    }
}
