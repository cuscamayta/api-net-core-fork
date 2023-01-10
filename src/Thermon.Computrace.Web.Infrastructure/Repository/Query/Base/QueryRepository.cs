using Microsoft.Extensions.Configuration;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;
using Thermon.Computrace.Web.Infrastructure.Data;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query.Base
{
    // Generic Query repository class
    public class QueryRepository<T> : DbConnector,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
