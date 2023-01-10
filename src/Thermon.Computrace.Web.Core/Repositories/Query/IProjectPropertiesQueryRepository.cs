using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Core.Repositories.Query
{    
    public interface IProjectPropertiesQueryRepository : IQueryRepository<Properties>
    {        
        Task<Properties> GetPropertiesByProjectIdAsync(Int64 id);        
    }
}
