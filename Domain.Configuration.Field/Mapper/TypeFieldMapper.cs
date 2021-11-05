using AutoMapper;
using Domain.Configuration.Field.Input;
using Domain.Configuration.Field.Output;
using Domain.Field;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration.Field.Mapper
{
    public class TypeFieldMapper : Profile
    {
        public TypeFieldMapper()
        {

            CreateMap<TypeField, TypeFieldOutPut>(MemberList.Source)
                .ForMember(x => x.Validations , opts => opts.Ignore());

            CreateMap<TypeFieldInputCreate, TypeField>(MemberList.Source)
                .ForMember(x => x.CreateDate, opts => opts.MapFrom(s => DateTime.Now))
                .ForMember(x => x.DeleteDate, opts => opts.Ignore())
                .ForMember(x => x.IsDelete, opts => opts.MapFrom(s => false))
                .ForMember(x => x.Id, opts => opts.MapFrom(s => Guid.NewGuid()))
                .ForMember(x => x.Validations, opts => opts.Ignore())
                ;

            CreateMap<Tuple<TypeFieldInputUpdate, TypeField>, TypeField>(MemberList.Source)
                .ForMember(x => x.CreateDate, opts => opts.MapFrom(s => s.Item2.CreateDate))
                .ForMember(x => x.DeleteDate, opts => opts.MapFrom(s => s.Item2.DeleteDate))
                .ForMember(x => x.IsDelete, opts => opts.MapFrom(s => s.Item2.IsDelete))
                .ForMember(x => x.Id, opts => opts.MapFrom(s => s.Item2.Id))
                .ForMember(x => x.Type, opts => opts.MapFrom(s => s.Item1.Type))
                .ForMember(x => x.TypeName, opts => opts.MapFrom(s => s.Item1.TypeName))
                .ForMember(x => x.Description, opts => opts.MapFrom(s => s.Item1.Description))
                .ForMember(x => x.Validations, opts => opts.Ignore())
                ;

        }

    }
}
