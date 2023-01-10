using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Profiles
{
    public record GetAllConnectionInfoQuery : IRequest<List<ConnectionInfoResponse>>
    {

    }
}
