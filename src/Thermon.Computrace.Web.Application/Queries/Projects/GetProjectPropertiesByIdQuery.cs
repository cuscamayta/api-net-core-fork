using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    public class GetProjectPropertiesByIdQuery : IRequest<Properties>
    {
        public long Id { get; private set; }

        public GetProjectPropertiesByIdQuery(long Id)
        {
            this.Id = Id;
        }

    }
}
