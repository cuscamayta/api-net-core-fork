using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Commands.Profile
{
    public class DeleteConnectionInfoCommand : IRequest<string>
    {
        public string Id { get; private set; }

        public DeleteConnectionInfoCommand(string Id)
        {
            this.Id = Id;
        }
    }
}
