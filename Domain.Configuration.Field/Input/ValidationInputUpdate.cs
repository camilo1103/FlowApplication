using Domain.Field;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Field.Input
{
    public class ValidationInputUpdate
    {
        public string Id { get; set; }
        public ValidationsEnum ValidationEnum { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
