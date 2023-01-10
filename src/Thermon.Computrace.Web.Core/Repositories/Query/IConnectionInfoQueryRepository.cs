using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{
    public interface IConnectionInfoQueryRepository : IQueryRepository<ConnectionInfo>
    {
        Task<IReadOnlyList<ConnectionInfo>> GetAllAsync();
        Task<ConnectionInfo> GetByIdAsync(Int64 id);
        Task<ConnectionInfo> GetByConnectionIdAsync(string id);
        Task<ConnectionInfo> GetConnectionInfoByEmail(string email);
    }
}
