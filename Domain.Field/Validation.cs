using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Configuration.Entity;

namespace Domain.Field
{
    public class Validation : Entity<Guid>
    {
        public ValidationsEnum ValidationEnum { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
