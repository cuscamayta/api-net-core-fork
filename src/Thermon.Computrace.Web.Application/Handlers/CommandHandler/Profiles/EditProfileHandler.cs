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
using Thermon.Computrace.Web.Core.Repositories.Query;
using entities = Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Profiles
{
    public class EditProfileHandler : IRequestHandler<EditProfileCommand, ProfileResponse>
    {
        private readonly IProfileCommandRepository _profileCommandRepository;
        private readonly IProfileQueryRepository _profileQueryRepository;
        public EditProfileHandler(IProfileCommandRepository profileRepository, IProfileQueryRepository profileQueryRepository)
        {
            _profileCommandRepository = profileRepository;
            _profileQueryRepository = profileQueryRepository;
        }
        public async Task<ProfileResponse> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = ProfileMapper.Mapper.Map<entities.Profiles>(request);

            if (profileEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _profileCommandRepository.UpdateAsync(profileEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedProfile = await _profileQueryRepository.GetByIdAsync(request.ProfileId);
            var profileResponse = ProfileMapper.Mapper.Map<ProfileResponse>(modifiedProfile);

            return profileResponse;
        }
    }
}
