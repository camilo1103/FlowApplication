using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Configuration.Field.Input;
using Domain.Configuration.Field.Output;
using Domain.Field;

namespace Domain.Configuration.Field.Mapper
{
    public class ValidationMapper : Profile
    {
        public ValidationMapper() {
            CreateMap<Validation, ValidationOutput>();
            CreateMap<ValidationInputCreate, Validation>(MemberList.Source)
                .ForMember(x => x.CreateDate, opts => opts.MapFrom(s => DateTime.Now))
                .ForMember(x => x.DeleteDate, opts => opts.Ignore())
                .ForMember(x => x.IsDelete, opts => opts.MapFrom(s => false))
                .ForMember(x => x.Id, opts => opts.MapFrom(s => Guid.NewGuid()))
                ;
            CreateMap<Tuple<ValidationInputUpdate, Validation>, Validation>(MemberList.Source)
                .ForMember(x => x.CreateDate, opts => opts.MapFrom(s => s.Item2.CreateDate))
                .ForMember(x => x.DeleteDate, opts => opts.MapFrom(s => s.Item2.DeleteDate))
                .ForMember(x => x.IsDelete, opts => opts.MapFrom(s => s.Item2.IsDelete))
                .ForMember(x => x.Id, opts => opts.MapFrom(s => s.Item2.Id))
                .ForMember(x => x.ValidationEnum, opts => opts.MapFrom(s => s.Item1.ValidationEnum))
                .ForMember(x => x.Description, opts => opts.MapFrom(s => s.Item1.Description))
                .ForMember(x => x.Value, opts => opts.MapFrom(s => s.Item1.Value))
                ;
        }
    }
}
