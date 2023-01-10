using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Repositories.Query;
using Thermon.Computrace.Web.Application.Response;
using AutoMapper;
using Thermon.Computrace.Web.Application.Queries.Projects;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Projects
{
    public class GetProjectPropertiesByIdHandler : IRequestHandler<GetProjectPropertiesByIdQuery, Properties>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProjectPropertiesQueryRepository _projectPropertyQueryRepository;

        public GetProjectPropertiesByIdHandler(IMapper mapper, IProjectPropertiesQueryRepository projectPropertyQueryRepository)
        {
            _projectPropertyQueryRepository = projectPropertyQueryRepository;
            _mapper = mapper;
        }

        //TODO map the properties with the result
        public Task<Properties> Handle(GetProjectPropertiesByIdQuery request, CancellationToken cancellationToken)
        {
            var selectedProjectProperties = _projectPropertyQueryRepository.GetPropertiesByProjectIdAsync(request.Id);

            return selectedProjectProperties;
        }
    }
}
