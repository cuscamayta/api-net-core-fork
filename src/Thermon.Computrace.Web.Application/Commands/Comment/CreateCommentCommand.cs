using MediatR;
using System;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Commands.Comment
{
    public class CreateCommentCommand : IRequest<CommentResponse>
    {

        public int CommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public string Version { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }

        public CreateCommentCommand()
        {
            CreatedDate = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}
