using Domain.Configuration.Field.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Field.Interfaces.Validation
{
    public interface IValidationApplication
    {
        Task<List<ValidationOutput>> Get();
    }
}
