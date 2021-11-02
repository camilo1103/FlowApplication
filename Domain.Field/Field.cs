using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Utilities.Configuration.Entity;

namespace Domain.Field
{
    [Table("Field")]
    public class Field : Entity<Guid>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public TypeField TypeField { get; set; }

    }
}
