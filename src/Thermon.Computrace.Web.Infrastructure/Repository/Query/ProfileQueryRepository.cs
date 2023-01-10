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
    public class ProfileQueryRepository : QueryRepository<Profiles>, IProfileQueryRepository
    {
        public ProfileQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Profiles>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM PROFILES";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Profiles>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Profiles> GetByIdAsync(string id)
        {
            try
            {
                var query = "SELECT * FROM PROFILES WHERE profileId = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Profiles>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Profiles> GetProfileByEmail(string email)
        {
            try
            {
                var query = "SELECT * FROM PROFILES WHERE email = @email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Profiles>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }
}
