using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Mapper.Profiles;
using Thermon.Computrace.Web.Application.Queries.ConnectionInfo;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Profiles
{
    public class GetConnectionsInfoByIdsHandler : IRequestHandler<GetConnectionsInfoByIdsQuery, List<ConnectionInfoResponse>>
    {
        private readonly IMediator _mediator;

        public GetConnectionsInfoByIdsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<ConnectionInfoResponse>> Handle(GetConnectionsInfoByIdsQuery request, CancellationToken cancellationToken)
        {
            var profile = await _mediator.Send(new GetAllConnectionInfoQuery());

            var connectionIds = request.Ids.Select(x => x.ToLower()).ToList();

            var connectionsForProfile = profile.Where(x => connectionIds.Contains(x.ConnectionId));
            return ConnectionInfoMapper.Mapper.Map<List<ConnectionInfoResponse>>(connectionsForProfile);
        }
    }
}
