using MediatR;
using System;

namespace Thermon.Computrace.Web.Application.Commands.Project
{
    // Project create command with string response
    public class DeleteProjectCommand : IRequest<string>
    {
        public int Id { get; private set; }

        public DeleteProjectCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
