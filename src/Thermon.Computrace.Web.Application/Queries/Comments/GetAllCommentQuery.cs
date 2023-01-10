using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System.Collections.Generic;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Comments
{
    public record GetAllCommentQuery : IRequest<List<CommentResponse>>
    {

    }
}
