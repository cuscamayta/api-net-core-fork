using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Commands.Profile
{
    public class EditProfileCommand : IRequest<ProfileResponse>
    {
        public string ProfileId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
