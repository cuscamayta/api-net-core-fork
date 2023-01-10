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
    public class EditConnectionInfoHandler : IRequestHandler<EditConnectionInfoCommand, ConnectionInfoResponse>
    {
        private readonly IConnectionInfoCommandRepository _connectionInfoCommandRepository;
        private readonly IConnectionInfoQueryRepository _connectionInfoQueryRepository;
        public EditConnectionInfoHandler(IConnectionInfoCommandRepository connectionInfoRepository, IConnectionInfoQueryRepository connectionInfoQueryRepository)
        {
            _connectionInfoCommandRepository = connectionInfoRepository;
            _connectionInfoQueryRepository = connectionInfoQueryRepository;
        }
        public async Task<ConnectionInfoResponse> Handle(EditConnectionInfoCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = ConnectionInfoMapper.Mapper.Map<entities.ConnectionInfo>(request);

            if (profileEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _connectionInfoCommandRepository.UpdateAsync(profileEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedProfile = await _connectionInfoQueryRepository.GetByConnectionIdAsync(request.ConnectionId);
            var profileResponse = ConnectionInfoMapper.Mapper.Map<ConnectionInfoResponse>(modifiedProfile);

            return profileResponse;
        }
    }
}
