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
using Thermon.Computrace.Web.Core.Repositories.Query;
using entities = Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Profiles
{
    public class GetAllProfilesHandler : IRequestHandler<GetAllProfilesQuery, List<ProfileResponse>>
    {
        private readonly IProfileQueryRepository _profileQueryRepository;

        public GetAllProfilesHandler(IProfileQueryRepository profileQueryRepository)
        {
            _profileQueryRepository = profileQueryRepository;
        }
        public async Task<List<ProfileResponse>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = (List<entities.Profiles>)await _profileQueryRepository.GetAllAsync();

            return ProfileMapper.Mapper.Map<List<ProfileResponse>>(profiles);
        }
    }
}
