using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Models;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{    
    public interface IProjectQueryRepository : IQueryRepository<Project>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(Int64 id);
        Task<Project> GetProjectByName(string email);
        Task<Response<List<ProjectInformationDto>>> GetProjectsByConnection(string connectionId);
        Task<Response<List<ProjectInformationDto>>> GetProjectsByConnectionList(List<string> connectionIds);
        Task<Response<List<ProjectDto>>> GetProjectDetails(ConnectionParameters connectionDetail);
        Task<Response<ProjectProperties>> GetProjectProperties(ConnectionDetail connectionDetail);
        Task<Response<ProjectBillOfMaterials>> GetBillOfMaterialsByProject(ConnectionDetail connectionDetail);
        Task<Response<List<CircuitsDto>>> GetCircuitsByProjects(ConnectionDetail connectionDetail);
        Task<Response<List<SegmentsDto>>> GetSegments(ConnectionParameters connectionDetail);
        Task<Response<ProjectBillOfMaterials>> GetBillOfMaterialsPdf(string projectId, string circuitId, string segmentId);
    }
}
