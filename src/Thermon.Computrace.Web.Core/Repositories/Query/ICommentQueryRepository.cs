using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{
    public interface ICommentQueryRepository : IQueryRepository<Comments>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Comments>> GetAllAsync();
        Task<Comments> GetByIdAsync(Int64 id);
    }
}
