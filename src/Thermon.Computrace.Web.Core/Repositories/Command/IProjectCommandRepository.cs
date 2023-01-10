using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Models;
using Thermon.Computrace.Web.Core.Repositories.Command.Base;

namespace Thermon.Computrace.Web.Core.Repositories.Command
{
    // Interface for project command repository
    public interface IProjectCommandRepository : ICommandRepository<Project>
    {
        Task<Response<bool>> ImportProject(string connectionId);
        Task<Response<bool>> ExportProject(ConnectionDetail connectionDetail);
        Task<Response<bool>> DeleteProject(ConnectionDetail connectionDetail);
        Task<Response<ProjectDto>> EditProject(ProjectDto project, ConnectionDetail connectionDetail);
        Task<Response<ProjectDto>> CreateProject(ProjectDto project, ConnectionDetail connectionDetail);
    }
}
