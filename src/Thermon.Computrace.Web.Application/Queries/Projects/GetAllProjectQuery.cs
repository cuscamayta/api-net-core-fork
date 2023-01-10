using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System.Collections.Generic;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    public record GetAllProjectQuery : IRequest<List<ProjectResponse>>
    {

    }
}
