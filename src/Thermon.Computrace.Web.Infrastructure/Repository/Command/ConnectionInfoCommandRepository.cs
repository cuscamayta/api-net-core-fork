using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Infrastructure.Data;
using Thermon.Computrace.Web.Infrastructure.Repository.Command.Base;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Command
{
    public class ConnectionInfoCommandRepository : CommandRepository<ConnectionInfo>, IConnectionInfoCommandRepository
    {
        public ConnectionInfoCommandRepository(ComputraceContext context) : base(context)
        {

        }
    }
}
