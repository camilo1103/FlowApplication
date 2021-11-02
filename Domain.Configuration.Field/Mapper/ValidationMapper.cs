using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Configuration.Field.Output;
using Domain.Field;

namespace Domain.Configuration.Field.Mapper
{
    public class ValidationMapper : Profile
    {
        public ValidationMapper() {
            CreateMap<Validation, ValidationOutput>();
        }
    }
}
