using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Mapper.Projects;
using Thermon.Computrace.Web.Application.Queries.Projects;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Projects
{
    public class GetBomProjectProperties : IRequestHandler<GetProjectBomSummaryByIdQuery, ProjectBomPropertiesResponse>
    {
        private readonly ICircuitQueryRepository _circuitsQueryRepository;

        public GetBomProjectProperties(ICircuitQueryRepository circuitsQueryRepository)
        {
            _circuitsQueryRepository = circuitsQueryRepository;
        }
        public async Task<ProjectBomPropertiesResponse> Handle(GetProjectBomSummaryByIdQuery request, CancellationToken cancellationToken)
        {
            var circuits = (List<Circuits>)await _circuitsQueryRepository.GetCircuitsByProjectIdAsync(request.Id);

            return new ProjectBomPropertiesResponse()
            {
                Circuits = circuits.Select(x => new CircuitsDto()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    //Segments = x.Segments.Select(y => new SegmentsDto()
                    //{
                    //    Id = y.Id,
                    //    Name = y.Name,
                    //    Items = y.Items.Select(z => new ItemsDto()
                    //    {
                    //        CatalogNumber = z.CatalogNumber,
                    //        Id = z.Id,
                    //        Quantity = z.Quantity,
                    //        ShortDescription = z.ShorDescription,
                    //        Units = z.Units
                    //    }).ToList()
                    //}).ToList()
                }).ToList()
            };
        }
    }
}
