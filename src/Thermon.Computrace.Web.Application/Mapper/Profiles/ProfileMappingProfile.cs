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
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<entities.Profiles, ProfileResponse>().ReverseMap();
            CreateMap<entities.Profiles, CreateProfileCommand>().ReverseMap();
            CreateMap<entities.Profiles, EditProfileCommand>().ReverseMap();
            CreateMap<entities.Profiles, ProfileResponse>().ReverseMap();
        }
    }
}
