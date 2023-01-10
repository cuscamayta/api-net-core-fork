using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Queries.Profiles
{
    public class GetProfileByEmailQuery:IRequest<ProfileResponse>
    {
        public string Email { get; private set; }

        public GetProfileByEmailQuery(string email)
        {
            this.Email = email;
        }
    }
}
