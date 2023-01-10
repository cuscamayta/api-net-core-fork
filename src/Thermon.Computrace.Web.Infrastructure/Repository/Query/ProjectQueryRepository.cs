using Dapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using Thermon.Computrace.Web.Infrastructure.Repository.Query.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Models;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query
{    
    public class ProjectQueryRepository : QueryRepository<Project>, IProjectQueryRepository
    {
        public ProjectQueryRepository(IConfiguration configuration) 
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Project>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM PROJECTS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Project>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public Task<Response<ProjectBillOfMaterials>> GetBillOfMaterialsByProject(ConnectionDetail connectionDetail)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProjectBillOfMaterials>> GetBillOfMaterialsPdf(string projectId, string circuitId, string segmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM PROJECTS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Project>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public Task<Response<List<CircuitsDto>>> GetCircuitsByProjects(ConnectionDetail connectionDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectByName(string name)
        {
            try
            {
                var query = "SELECT * FROM PROJECTS WHERE Name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("Name", name, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Project>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public Task<Response<List<ProjectDto>>> GetProjectDetails(ConnectionParameters connectionDetail)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProjectProperties>> GetProjectProperties(ConnectionDetail connectionDetail)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProjectInformationDto>>> GetProjectsByConnection(string connectionId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ProjectInformationDto>>> GetProjectsByConnectionList(List<string> connectionIds)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<SegmentsDto>>> GetSegments(ConnectionParameters connectionDetail)
        {
            throw new NotImplementedException();
        }
    }
}
