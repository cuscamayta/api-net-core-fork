using MediatR;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Queries.Comments;
using Thermon.Computrace.Web.Application.Mapper.Commet;

namespace Thermon.Computrace.Web.Application.Handlers.QueryHandlers.Comment
{
    public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, List<CommentResponse>>
    {
        private readonly ICommentQueryRepository _commentQueryRepository;

        public GetAllCommentHandler(ICommentQueryRepository commentQueryRepository)
        {
            _commentQueryRepository = commentQueryRepository;
        }
        public async Task<List<CommentResponse>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = (List<Comments>)await _commentQueryRepository.GetAllAsync();

            return CommentMapper.Mapper.Map<List<CommentResponse>>(comments);
        }
    }
}
