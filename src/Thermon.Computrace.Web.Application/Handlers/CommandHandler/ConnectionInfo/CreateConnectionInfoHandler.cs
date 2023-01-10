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
    public class CreateConnectionInfoHandler : IRequestHandler<CreateConnectionInfoCommand, ConnectionInfoResponse>
    {
        private readonly IConnectionInfoCommandRepository _connectionInfoCommandRepository;
        public CreateConnectionInfoHandler(IConnectionInfoCommandRepository connectionInfoCommandRepository)
        {
            _connectionInfoCommandRepository = connectionInfoCommandRepository;
        }
        public async Task<ConnectionInfoResponse> Handle(CreateConnectionInfoCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = ConnectionInfoMapper.Mapper.Map<entities.ConnectionInfo>(request);

            if (profileEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            profileEntity.ConnectionId =  Guid.NewGuid();
            var newProfile = await _connectionInfoCommandRepository.AddAsync(profileEntity);
            var profileResponse = ConnectionInfoMapper.Mapper.Map<ConnectionInfoResponse>(newProfile);
            return profileResponse;
        }
    }
}
