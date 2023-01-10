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
    public class GetProfileByEmailHandler : IRequestHandler<GetProfileByEmailQuery, ProfileResponse>
    {
        private readonly IMediator _mediator;

        public GetProfileByEmailHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProfileResponse> Handle(GetProfileByEmailQuery request, CancellationToken cancellationToken)
        {
            var profile = await _mediator.Send(new GetAllProfilesQuery());
            var selectedProfile = profile.FirstOrDefault(x => x.Email.ToLower() == request.Email.ToLower());
            return selectedProfile;
        }
    }
}
