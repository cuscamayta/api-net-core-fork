using MediatR;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Project;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Projects
{
    // Project delete command handler with string response as output
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, string>
    {
        private readonly IProjectCommandRepository _projectCommandRepository;
        private readonly IProjectQueryRepository _projectQueryRepository;
        public DeleteProjectHandler(IProjectCommandRepository projectRepository, IProjectQueryRepository projectQueryRepository)
        {
            _projectCommandRepository = projectRepository;
            _projectQueryRepository = projectQueryRepository;
        }

        public async Task<string> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var projectEntity = await _projectQueryRepository.GetByIdAsync(request.Id);

                await _projectCommandRepository.DeleteAsync(projectEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            return "Project information has been deleted!";
        }
    }
}
