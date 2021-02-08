using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BRQ_Test.Domain.Enums;
using BRQ_Test.Domain.Models;
using BRQ_Test.Domain.ViewModel;

namespace BRQ_Test.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TruckViewModel, Truck>().ReverseMap()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.ToString()));

            CreateMap<Truck, CreateTruckViewModel>().ReverseMap()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => ConvertEnum(src.Model)));

            CreateMap<Truck, UpdateTruckViewModel>().ReverseMap()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => ConvertEnum(src.Model)));
        }

        private ModelEnum ConvertEnum(string srcModel)
        {
            Enum.TryParse(srcModel, out ModelEnum myStatus);

            return myStatus;
        }
    }
}
