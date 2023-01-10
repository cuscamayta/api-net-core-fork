using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.ConnectionInfo
{
    public class GetConnectionsInfoByIdsQuery : IRequest<List<ConnectionInfoResponse>>
    {
        public List<string> Ids { get; private set; }

        public GetConnectionsInfoByIdsQuery(List<string> Ids)
        {
            this.Ids = Ids;
        }
    }
}
