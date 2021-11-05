using Application.Field.Interfaces.TypeFIeld;
using Domain.Configuration.Field.Input;
using Domain.Configuration.Field.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces.Repositories;
using Domain.Field;
using Utilities.Interfaces.UnitOfWorks;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Field.Implementation.TypeField
{
    public class TypeFieldApplication : ITypeFieldApplication
    {
        private readonly IRepositoryAsync<Domain.Field.TypeField> _typeFieldRepository;
        private readonly IRepositoryAsync<ValidationInField> _validationInFieldRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;

        public TypeFieldApplication(
            IRepositoryAsync<Domain.Field.TypeField> typeFieldRepository,
            IRepositoryAsync<ValidationInField> validationInFieldRepository,
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper)
        {
            _typeFieldRepository = typeFieldRepository;
            _validationInFieldRepository = validationInFieldRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TypeFieldOutPut> Create(TypeFieldInputCreate input)
        {
            var inputCreate = _mapper.Map<Domain.Field.TypeField>(input);
            var responseTypeField = await _typeFieldRepository.InsertAsync(inputCreate);
            await _unitOfWork.SaveChangesAsync();
            foreach (var Validation in input.ValidationsId)
            {
                var ValidationInput = new ValidationInField
                {
                    Id = Guid.NewGuid(),
                    ValidationId = Guid.Parse(Validation),
                    TypeFieldId = responseTypeField.Id
                };
                await _validationInFieldRepository.InsertAsync(ValidationInput);
                await _unitOfWork.SaveChangesAsync();
            }
            responseTypeField = _typeFieldRepository.Get()
                .Where(x => x.Id == responseTypeField.Id)
                .Include(x => x.Validations).ThenInclude(x => x.Validation).FirstOrDefault();
            var response = _mapper.Map<TypeFieldOutPut>(responseTypeField);
            response.Validations = _mapper.Map<List<ValidationOutput>>(responseTypeField.Validations.Select(x => x.Validation).ToList());
            return response;
        }

        public Task<TypeFieldOutPut> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TypeFieldOutPut>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TypeFieldOutPut> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TypeFieldOutPut> Update(TypeFieldInputUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
