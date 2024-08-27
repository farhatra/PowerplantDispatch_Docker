using AutoMapper;
using PowerplantDispatch.Application.DTOs;
using PowerplantDispatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductionPlanDto, ProductionPlan>().ReverseMap();
            CreateMap<PowerPlantDto, PowerPlant>().ReverseMap();
            CreateMap<FuelDto, Fuel>().ReverseMap();
            CreateMap<PowerOutputDto, PowerOutput>().ReverseMap();
        }
    }
}
