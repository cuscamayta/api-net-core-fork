using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Models;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Infrastructure.Data;
using Thermon.Computrace.Web.Infrastructure.Repository.Command.Base;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Command
{
    // Command Repository class for project
    public class ProjectCommandRepository : CommandRepository<Project>, IProjectCommandRepository
    {
        public ProjectCommandRepository(ComputraceContext context) : base(context)
        {

        }

        public Task<Response<ProjectDto>> CreateProject(ProjectDto project, ConnectionDetail connectionDetail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> DeleteProject(ConnectionDetail connectionDetail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProjectDto>> EditProject(ProjectDto project, ConnectionDetail connectionDetail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> ExportProject(ConnectionDetail connectionDetail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> ImportProject(string connectionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
