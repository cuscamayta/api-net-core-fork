using AutoMapper;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Common.Extensions;
using Thermon.Computrace.Web.Application.Commands.Project;

namespace Thermon.Computrace.Web.Application.Mapper.Projects
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectResponse>().ReverseMap();
            CreateMap<Project, CreateProjectCommand>().ReverseMap();
            CreateMap<Project, EditProjectCommand>().ReverseMap();

            CreateMap<Project, ProjectResponse>()
                    .ForMember(dest => dest.DatabaseConnectionString, source => source.MapFrom(source => source.DatabaseConnectionString.ToAESEncryption()))
                    .ReverseMap();
        }
    }
}
