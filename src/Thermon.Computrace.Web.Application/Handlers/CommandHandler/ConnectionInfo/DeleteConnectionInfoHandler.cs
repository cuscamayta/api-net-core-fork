using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Core.Repositories.Query;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Profiles
{
    public class DeleteConnectionInfoHandler:IRequestHandler<DeleteConnectionInfoCommand, string>
    {
        private readonly IConnectionInfoCommandRepository _connectionInfoCommandRepository;
        private readonly IConnectionInfoQueryRepository _connectionInfoQueryRepository;
        public DeleteConnectionInfoHandler(IConnectionInfoCommandRepository connectionInfoRepository, IConnectionInfoQueryRepository connectionInfoQueryRepository)
        {
            _connectionInfoCommandRepository = connectionInfoRepository;
            _connectionInfoQueryRepository = connectionInfoQueryRepository;
        }

        public async Task<string> Handle(DeleteConnectionInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var profileEntity = await _connectionInfoQueryRepository.GetByConnectionIdAsync(request.Id);

                await _connectionInfoCommandRepository.DeleteAsync(profileEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            return "Profile information has been deleted!";
        }
    }
}
