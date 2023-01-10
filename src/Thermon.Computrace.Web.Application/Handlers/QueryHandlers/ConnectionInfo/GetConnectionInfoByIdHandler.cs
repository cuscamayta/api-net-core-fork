using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Mapper.Profiles;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Profiles
{
    public class GetConnectionInfoByIdHandler : IRequestHandler<GetConnectionInfoByIdQuery, List<ConnectionInfoResponse>>
    {
        private readonly IMediator _mediator;

        public GetConnectionInfoByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<ConnectionInfoResponse>> Handle(GetConnectionInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _mediator.Send(new GetAllConnectionInfoQuery());
            var connectionsForProfile = profile.Where(x => x.UserProfileId.ToUpper() == request.Id.ToUpper());
            return ConnectionInfoMapper.Mapper.Map<List<ConnectionInfoResponse>>(connectionsForProfile);
        }
    }
}
