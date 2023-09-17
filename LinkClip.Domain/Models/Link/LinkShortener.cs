using LinkClip.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Domain.Models.Link
{
    public class LinkShortener : BaseEntity
    {
        [Display(Name = "OriginalUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public Uri OriginalUrl { get; set; }
        [Display(Name = "FullUrl")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(400,ErrorMessage = "{0} cannot be more than {1} characters")]
        public Uri Value { get; set; }
        [Display(Name = "Token")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(40, ErrorMessage = "{0} cannot be more than {1} characters")]
        public string Token { get; set; }


        //relation
        public ICollection<RequestUrl> RequestUrls { get; set; }
    }
}
