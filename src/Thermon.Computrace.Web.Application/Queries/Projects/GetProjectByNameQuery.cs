using MediatR;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    // Project GetProjectByNameQuery with Project response
    public class GetProjectByNameQuery : IRequest<ProjectResponse>
    {
        public string Name { get; private set; }

        public GetProjectByNameQuery(string name)
        {
            Name = name;
        }

    }
}
