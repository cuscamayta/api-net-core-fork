using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Commands.Profile
{
    public class DeleteProfileCommand : IRequest<string>
    {
        public string Id { get; private set; }

        public DeleteProfileCommand(string Id)
        {
            this.Id = Id;
        }
    }
}
