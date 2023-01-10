using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Queries.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Projects
{
    // Get specific project query handler with Project response as output
    public class GetProjectByNameHandler : IRequestHandler<GetProjectByNameQuery, ProjectResponse>
    {
        private readonly IMediator _mediator;

        public GetProjectByNameHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProjectResponse> Handle(GetProjectByNameQuery request, CancellationToken cancellationToken)
        {
            var projects = await _mediator.Send(new GetAllProjectQuery());
            var selectedProject = projects.FirstOrDefault(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            return selectedProject;
        }
    }
}
