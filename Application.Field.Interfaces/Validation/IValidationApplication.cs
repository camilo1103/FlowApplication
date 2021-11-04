using Domain.Configuration.Field.Input;
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
        Task<ValidationOutput> GetById(Guid id);
        Task<Domain.Field.Validation> Create(ValidationInputCreate input);
        Task<Domain.Field.Validation> Update(ValidationInputUpdate input);
        Task<Domain.Field.Validation> Delete(Guid id);
    }
}
