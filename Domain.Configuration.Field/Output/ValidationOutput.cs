using Domain.Field;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Field.Output
{
    public class ValidationOutput
    {
        public Guid Id { get; set; }
        public ValidationsEnum ValidationEnum { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
