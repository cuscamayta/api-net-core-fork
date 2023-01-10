using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Application.Response;
using entities = Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Mapper.Profiles
{
    public class ConnectionInfoMappingProfile : Profile
    {
        public ConnectionInfoMappingProfile()
        {
            CreateMap<entities.ConnectionInfo, ConnectionInfoResponse>().ReverseMap();
            CreateMap<entities.ConnectionInfo, CreateConnectionInfoCommand>().ReverseMap();
            CreateMap<entities.ConnectionInfo, EditConnectionInfoCommand>().ReverseMap();
            CreateMap<entities.ConnectionInfo, ConnectionInfoResponse>().ReverseMap();
        }
    }
}
