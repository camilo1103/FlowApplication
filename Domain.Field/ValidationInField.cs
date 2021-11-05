using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Utilities.Configuration.Entity;

namespace Domain.Field
{
    [Table("ValidationInField")]
    public class ValidationInField : Entity<Guid>
    {
        public Guid TypeFieldId { get; set; }
        [ForeignKey("TypeFieldId")]
        public TypeField TypeField { get; set; }

        public Guid ValidationId { get; set; }
        [ForeignKey("ValidationId")]
        public Validation Validation { get; set; }
    }
}
