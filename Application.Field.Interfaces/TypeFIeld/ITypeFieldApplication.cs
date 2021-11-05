using Domain.Configuration.Field.Input;
using Domain.Configuration.Field.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Field.Interfaces.TypeFIeld
{
    public interface ITypeFieldApplication
    {
        Task<List<TypeFieldOutPut>> Get();
        Task<TypeFieldOutPut> GetById(Guid id);
        Task<TypeFieldOutPut> Create(TypeFieldInputCreate input);
        Task<TypeFieldOutPut> Update(TypeFieldInputUpdate input);
        Task<TypeFieldOutPut> Delete(Guid id);
    }
}
