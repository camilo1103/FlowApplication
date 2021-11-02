using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Utilities.Configuration.Entity;

namespace Domain.Field
{
    [Table("TypeField")]
    public class TypeField : Entity<Guid>
    {
        [Required]
        public string TypeName {get; set;}

        [Required]
        public TypeFieldEnum Type { get; set; }

        [Required]
        public List<Validation> Validations { get; set; }

        [Required]
        public string Description { get; set; }
    }   
}
