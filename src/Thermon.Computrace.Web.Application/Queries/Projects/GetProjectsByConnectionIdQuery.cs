using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    public class GetProjectsByConnectionIdQuery
    {
        public string ConnectionId { get; private set; }

        public GetProjectsByConnectionIdQuery(string connectionId)
        {
            this.ConnectionId = connectionId;
        }
    }
}
