using Application.Field.Interfaces.Validation;
using AutoMapper;
using Domain.Configuration.Field.Input;
using Domain.Configuration.Field.Output;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces.Repositories;
using Utilities.Interfaces.UnitOfWorks;

namespace Application.Field.Implementation.Validation
{   
    public class ValidationApplication: IValidationApplication
    {
        private readonly IRepositoryAsync<Domain.Field.Validation> _validationRepository;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;
        public ValidationApplication(IRepositoryAsync<Domain.Field.Validation> validationRepository, IUnitOfWorkAsync unitOfWork, IMapper mapper) {
            _validationRepository = validationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Domain.Field.Validation> Create(ValidationInputCreate input)
        {
            Domain.Field.Validation inputCreate = _mapper.Map<Domain.Field.Validation>(input);
            var result = await _validationRepository.InsertAsync(inputCreate);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<Domain.Field.Validation> Delete(Guid id)
        {
            var Validate = _validationRepository.GetAll(true).Where(x => x.Id == id).FirstOrDefault();
            Validate.DeleteDate = DateTime.Now;
            Validate.IsDelete = true;
            var response = await _validationRepository.UpdateAsync(Validate);
            await _unitOfWork.SaveChangesAsync();
            return response;
        }

        public async Task<List<ValidationOutput>> Get()
        {
            var response = await _validationRepository.GetAll().ToListAsync();
            return _mapper.Map<List<ValidationOutput>>(response);
        }

        public async Task<ValidationOutput> GetById(Guid id)
        {
            var response = await _validationRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ValidationOutput>(response);
        }

        public async Task<Domain.Field.Validation> Update(ValidationInputUpdate input)
        {
            var Validate = _validationRepository.GetAll().Where(x => x.Id == Guid.Parse(input.Id)).FirstOrDefault();
            var inputUpdate = _mapper.Map<Domain.Field.Validation>(new Tuple<ValidationInputUpdate, Domain.Field.Validation>(input, Validate));
            var response = await _validationRepository.UpdateAsync(inputUpdate);
            await _unitOfWork.SaveChangesAsync();
            return response;
        }
    }
}
