using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Field
{
    public enum TypeFieldEnum
    {
        [Display(Name = "Text")]
        Text,
        [Display(Name = "Number")]
        Number,
        [Display(Name = "Double")]
        Double,
        [Display(Name = "Boolean")]
        Boolean,
        [Display(Name = "Date")]
        Date,
        [Display(Name = "File")]
        File,
        [Display(Name = "Image")]
        Image
    }
}
