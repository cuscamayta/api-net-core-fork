using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Core.Repositories.Query;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Profiles
{
    public class DeleteProfileHandler:IRequestHandler<DeleteProfileCommand, string>
    {
        private readonly IProfileCommandRepository _profileCommandRepository;
        private readonly IProfileQueryRepository _profileQueryRepository;
        public DeleteProfileHandler(IProfileCommandRepository profileRepository, IProfileQueryRepository profileQueryRepository)
        {
            _profileCommandRepository = profileRepository;
            _profileQueryRepository = profileQueryRepository;
        }

        public async Task<string> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var profileEntity = await _profileQueryRepository.GetByIdAsync(request.Id);

                await _profileCommandRepository.DeleteAsync(profileEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            return "Profile information has been deleted!";
        }
    }
}
