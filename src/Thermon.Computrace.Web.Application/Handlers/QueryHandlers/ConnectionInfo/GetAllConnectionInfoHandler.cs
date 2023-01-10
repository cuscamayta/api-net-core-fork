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
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using entities = Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Profiles
{
    public class GetAllConnectionInfoHandler : IRequestHandler<GetAllConnectionInfoQuery, List<ConnectionInfoResponse>>
    {
        private readonly IConnectionInfoQueryRepository _connectionInfoQueryRepository;

        public GetAllConnectionInfoHandler(IConnectionInfoQueryRepository connectionInfoQueryRepository)
        {
            _connectionInfoQueryRepository = connectionInfoQueryRepository;
        }
        public async Task<List<ConnectionInfoResponse>> Handle(GetAllConnectionInfoQuery request, CancellationToken cancellationToken)
        {
            var profiles = (List<ConnectionInfo>)await _connectionInfoQueryRepository.GetAllAsync();

            return ConnectionInfoMapper.Mapper.Map<List<ConnectionInfoResponse>>(profiles);
        }
    }
}
