using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Mapper.Projects;
using Thermon.Computrace.Web.Application.Queries.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Projects
{
    // Get all project query handler with List<Project> response as output
    public class GetAllProjectHandler : IRequestHandler<GetAllProjectQuery, List<ProjectResponse>>
    {
        private readonly IProjectQueryRepository _projectQueryRepository;

        public GetAllProjectHandler(IProjectQueryRepository projectQueryRepository)
        {
            _projectQueryRepository = projectQueryRepository;
        }
        public async Task<List<ProjectResponse>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = (List<Project>)await _projectQueryRepository.GetAllAsync();

            return ProjectMapper.Mapper.Map<List<ProjectResponse>>(projects);
        }
    }
}
