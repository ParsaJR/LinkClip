using LinkClip.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkClip.Domain.Models.Link
{
    public class RequestUrl : BaseEntity
    {
        [Display(Name = "UrlCode")]
        public long LinkShortenerId { get; set; }
        [Display(Name = "RequestDate")]
        public DateTime RequestDateTime { get; set; }

        //ralation
        public LinkShortener LinkShortener { get; set; }
    }
}
