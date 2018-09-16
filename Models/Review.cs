using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Restauranter.Models
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
            : base(typeof(DateTime), 
                    DateTime.Now.AddYears(-6).ToShortDateString(),
                    DateTime.Now.ToShortDateString()) 
        { } 
    }
    public class Review
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Restaurant { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public int Star { get; set; }

        [Required]
        [CustomDateAttribute(ErrorMessage="Date must not be in the future.")]
        public DateTime Date { get; set; }
    }  
}