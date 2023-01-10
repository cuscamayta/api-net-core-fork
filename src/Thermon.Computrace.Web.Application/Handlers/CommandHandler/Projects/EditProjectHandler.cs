using MediatR;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Project;
using Thermon.Computrace.Web.Application.Mapper.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Projects
{
    // Project edit command handler with project response as output
    public class EditProjectHandler : IRequestHandler<EditProjectCommand, ProjectResponse>
    {
        private readonly IProjectCommandRepository _projectCommandRepository;
        private readonly IProjectQueryRepository _projectQueryRepository;
        public EditProjectHandler(IProjectCommandRepository projectRepository, IProjectQueryRepository projectQueryRepository)
        {
            _projectCommandRepository = projectRepository;
            _projectQueryRepository = projectQueryRepository;
        }
        public async Task<ProjectResponse> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = ProjectMapper.Mapper.Map<Project>(request);

            if (projectEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _projectCommandRepository.UpdateAsync(projectEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedProject = await _projectQueryRepository.GetByIdAsync(request.ProjectId);
            var projectResponse = ProjectMapper.Mapper.Map<ProjectResponse>(modifiedProject);

            return projectResponse;
        }
    }
}
