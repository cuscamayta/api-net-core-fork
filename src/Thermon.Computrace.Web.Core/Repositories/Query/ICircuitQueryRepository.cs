using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{
    public interface ICircuitQueryRepository : IQueryRepository<Circuits>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Circuits>> GetCircuitsByProjectIdAsync(long id);        
    }
}
