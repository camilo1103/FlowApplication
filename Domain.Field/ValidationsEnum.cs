using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Field
{
    public enum ValidationsEnum
    {
        [Display(Name = "Equal")]
        Equal,
        [Display(Name = "Length")]
        Length,
        [Display(Name = "Greater than")]
        GreaterThan,
        [Display(Name = "Less than")]
        LessThan,
        [Display(Name = "Regex")]
        Regex,
        [Display(Name = "Contains")]
        Contains,
        [Display(Name = "Custom")]
        Custom,
    }
}
