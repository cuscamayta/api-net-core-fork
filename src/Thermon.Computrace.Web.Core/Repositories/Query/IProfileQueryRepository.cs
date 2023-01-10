using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{
    public interface IProfileQueryRepository : IQueryRepository<Profiles>
    {
        Task<IReadOnlyList<Profiles>> GetAllAsync();
        Task<Profiles> GetByIdAsync(string id);
        Task<Profiles> GetProfileByEmail(string email);
    }
}
