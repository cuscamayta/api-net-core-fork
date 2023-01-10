using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    public class GetProjectBomSummaryByIdQuery : IRequest<ProjectBomPropertiesResponse>
    {
        public long Id { get; private set; }
        public GetProjectBomSummaryByIdQuery(long Id)
        {
            this.Id = Id;
        }
    }
}