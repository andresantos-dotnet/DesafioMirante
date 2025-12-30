using AutoMapper;
using Domain.Dtos.Activity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    public class EntitiyToDtoProfile : Profile
    {
        public EntitiyToDtoProfile() 
        {
            CreateMap<ActivityDto, Activity>();

            CreateMap<ActivityDtoCreateResult, Activity>();

            CreateMap<ActivityDtoUpdateResult, Activity>();


        }
    }
}
