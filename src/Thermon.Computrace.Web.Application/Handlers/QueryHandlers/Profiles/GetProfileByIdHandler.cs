using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Profiles
{
    public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdQuery, ProfileResponse>
    {
        private readonly IMediator _mediator;

        public GetProfileByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProfileResponse> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _mediator.Send(new GetAllProfilesQuery());
            var selectedProfile = profile.FirstOrDefault(x => x.ProfileId.ToString().ToLower() == request.Id.ToLower());
            return selectedProfile;
        }
    }
}
