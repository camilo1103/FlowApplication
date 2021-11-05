using Domain.Field;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Field.Output
{
    public class TypeFieldOutPut
    {
        public string TypeName { get; set; }

        public TypeFieldEnum Type { get; set; }

        public List<ValidationOutput> Validations { get; set; }

        public string Description { get; set; }
    }
}
