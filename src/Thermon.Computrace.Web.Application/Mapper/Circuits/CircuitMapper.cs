using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Mapper.Circuit
{
    public class CircuitMappingProfile : Profile
    {
        public CircuitMappingProfile()
        {
            CreateMap<Circuits, CircuitsDto>().ReverseMap();
        }
    }
}
