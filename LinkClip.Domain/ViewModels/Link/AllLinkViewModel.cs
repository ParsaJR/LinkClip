using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Domain.ViewModels.Link
{
    public class AllLinkViewModel
    {
        [Display(Name = "OriginalUrl")]
        public string OriginalUrl { get; set; }
        [Display(Name = "FullUrl")]

        public string Value { get; set; }
        [Display(Name = "Token")]

        public string Token { get; set; }
        [Display(Name = "CreateDate")]

        public DateTime CreateDate { get; set; }
    }
}
