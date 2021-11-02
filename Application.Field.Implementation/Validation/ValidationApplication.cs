using Application.Field.Interfaces.Validation;
using AutoMapper;
using Domain.Configuration.Field.Output;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces.Repositories;

namespace Application.Field.Implementation.Validation
{   
    public class ValidationApplication: IValidationApplication
    {
        private readonly IRepositoryAsync<Domain.Field.Validation> _validationRepository;
        private readonly IMapper _mapper;
        public ValidationApplication(IRepositoryAsync<Domain.Field.Validation> validationRepository, IMapper mapper) {
            _validationRepository = validationRepository;
            _mapper = mapper;
        }

        public async Task<List<ValidationOutput>> Get()
        {
            var response = await _validationRepository.GetAll().ToListAsync();
            return _mapper.Map<List<ValidationOutput>>(response);
        }
    }
}
