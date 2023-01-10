using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using Thermon.Computrace.Web.Infrastructure.Repository.Query.Base;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query
{
    public class ConnectionInfoQueryRepository : QueryRepository<ConnectionInfo>, IConnectionInfoQueryRepository
    {
        public ConnectionInfoQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<ConnectionInfo>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM CONNECTIONINFO";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<ConnectionInfo>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<ConnectionInfo> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM CONNECTIONINFO WHERE UserProfileId = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<ConnectionInfo>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<ConnectionInfo> GetByConnectionIdAsync(string id)
        {
            try
            {
                var query = "SELECT * FROM CONNECTIONINFO WHERE ConnectionId = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<ConnectionInfo>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<ConnectionInfo> GetConnectionInfoByEmail(string email)
        {
            try
            {
                var query = "SELECT * FROM CONNECTIONINFO WHERE UserName = @email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<ConnectionInfo>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }
}
