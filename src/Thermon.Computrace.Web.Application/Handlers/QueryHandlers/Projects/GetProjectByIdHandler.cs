using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Queries.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Projects
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectResponse>
    {
        private readonly IMediator _mediator;

        public GetProjectByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _mediator.Send(new GetAllProjectQuery());
            var selectedProject = project.FirstOrDefault(x => x.ProjectId == request.Id);
            return selectedProject;
        }
    }
}
