using AutoMapper;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Common.Extensions;
using Thermon.Computrace.Web.Application.Commands.Project;
using Thermon.Computrace.Web.Application.Commands.Comment;

namespace Thermon.Computrace.Web.Application.Mapper.Comment
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comments, CreateCommentCommand>().ReverseMap();
            CreateMap<Comments, CommentResponse>().ReverseMap();
        }
    }
}
