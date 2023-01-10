using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Commands.Project;
using Thermon.Computrace.Web.Application.Mapper.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Projects
{
    // Project create command handler with ProjectResponse as output
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectResponse>
    {
        private readonly IProjectCommandRepository _projectCommandRepository;
        public CreateProjectHandler(IProjectCommandRepository projectCommandRepository)
        {
            _projectCommandRepository = projectCommandRepository;
        }
        public async Task<ProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = ProjectMapper.Mapper.Map<Project>(request);

            if (projectEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newProject = await _projectCommandRepository.AddAsync(projectEntity);
            var projectResponse = ProjectMapper.Mapper.Map<ProjectResponse>(newProject);
            return projectResponse;
        }
    }
}
