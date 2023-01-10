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

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query
{    
    public class ProjectPropertiesQueryRepository : QueryRepository<Project>, IProjectPropertiesQueryRepository
    {
        public ProjectPropertiesQueryRepository(IConfiguration configuration) 
            : base(configuration)
        {

        }


        public async Task<Properties> GetPropertiesByProjectIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM PROPERTIES WHERE ProjectId = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Properties>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
