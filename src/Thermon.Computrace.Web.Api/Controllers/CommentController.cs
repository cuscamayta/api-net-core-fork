using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Comment;
using Thermon.Computrace.Web.Application.Queries.Comments;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Api.Controllers
{
    [Route("api/v1/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CommentResponse>> CreateComment([FromBody] CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<CommentResponse>> Get()
        {
            return await _mediator.Send(new GetAllCommentQuery());
        }
    }
}
