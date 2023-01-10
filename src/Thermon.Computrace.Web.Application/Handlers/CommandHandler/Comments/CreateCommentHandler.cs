using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Commands.Comment;
using Thermon.Computrace.Web.Application.Mapper.Commet;

namespace Thermon.Computrace.Web.Application.Handlers.CommandHandler.Projects
{
    // Project create command handler with ProjectResponse as output
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, CommentResponse>
    {
        private readonly ICommentCommandRepository _CommentCommandRepository;
        public CreateCommentHandler(ICommentCommandRepository projectCommandRepository)
        {
            _CommentCommandRepository = projectCommandRepository;
        }
        public async Task<CommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = CommentMapper.Mapper.Map<Comments>(request);

            if (commentEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newComment = await _CommentCommandRepository.AddAsync(commentEntity);
            var projectResponse = CommentMapper.Mapper.Map<CommentResponse>(newComment);
            return projectResponse;
        }
    }
}
