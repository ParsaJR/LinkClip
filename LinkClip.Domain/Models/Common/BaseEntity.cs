
using System.ComponentModel.DataAnnotations;


namespace LinkClip.Domain.Models.Common
{
    public class BaseEntity
    {
        //Primary Key
        [Key]
        public long Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }



    }
}
