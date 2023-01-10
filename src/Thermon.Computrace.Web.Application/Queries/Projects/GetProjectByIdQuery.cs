using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using System;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Projects
{
    public class GetProjectByIdQuery : IRequest<ProjectResponse>
    {
        public long Id { get; private set; }

        public GetProjectByIdQuery(long Id)
        {
            this.Id = Id;
        }

    }
}
