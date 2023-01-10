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

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query
{
    public class CommentQueryRepository : QueryRepository<Comments>, ICommentQueryRepository
    {
        public CommentQueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Comments>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM COMMENTS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Comments>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Comments> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM COMMENTS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Comments>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }
}
