using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Profiles
{
    public class GetProfileByIdQuery : IRequest<ProfileResponse>
    {
        public string Id { get; private set; }

        public GetProfileByIdQuery(string Id)
        {
            this.Id = Id;
        }
    }
}
