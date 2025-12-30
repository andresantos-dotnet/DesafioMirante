using AutoMapper;
using Domain.Dtos.Activity;
using Infra.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile() 
        {
            CreateMap<Activity, ActivityDto>();
        }
    }
}
