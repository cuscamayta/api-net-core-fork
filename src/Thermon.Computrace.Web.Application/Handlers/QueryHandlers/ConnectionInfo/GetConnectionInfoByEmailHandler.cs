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
    public class GetConnectionInfoByEmailHandler : IRequestHandler<GetConnectionInfoByEmailQuery, ConnectionInfoResponse>
    {
        private readonly IMediator _mediator;

        public GetConnectionInfoByEmailHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ConnectionInfoResponse> Handle(GetConnectionInfoByEmailQuery request, CancellationToken cancellationToken)
        {
            var profile = await _mediator.Send(new GetAllConnectionInfoQuery());
            var selectedProfile = profile.FirstOrDefault(x => x.UserName.ToLower() == request.Email.ToLower());
            return selectedProfile;
        }
    }
}
