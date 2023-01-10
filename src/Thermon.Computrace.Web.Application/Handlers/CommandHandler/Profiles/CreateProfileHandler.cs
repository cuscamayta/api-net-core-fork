using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Application.Mapper.Profiles;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Repositories.Command;
using entities = Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Profiles
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, ProfileResponse>
    {
        private readonly IProfileCommandRepository _profileCommandRepository;
        public CreateProfileHandler(IProfileCommandRepository profileCommandRepository)
        {
            _profileCommandRepository = profileCommandRepository;
        }
        public async Task<ProfileResponse> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = ProfileMapper.Mapper.Map<entities.Profiles>(request);

            if (profileEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            profileEntity.ProfileId = Guid.NewGuid();
            var newProfile = await _profileCommandRepository.AddAsync(profileEntity);
            var profileResponse = ProfileMapper.Mapper.Map<ProfileResponse>(newProfile);
            return profileResponse;
        }
    }
}
