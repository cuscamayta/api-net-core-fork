using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Common.Utilities;

namespace Thermon.Computrace.Web.Api.Controllers
{
    [Route("api/v1/connectioninfo")]
    [ApiController]
    public class ConnectionInfoController : Controller
    {
        private readonly IMediator _mediator;
        public ConnectionInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ConnectionInfoResponse>> CreateConnectionInfo([FromBody] CreateConnectionInfoCommand command)
        {
            if (!ConnectionUtils.ValidateConnectionString(command.ConnectionString))
            {
                return BadRequest("Invalid Connection string.");
            }
            else
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditConnectionInfo(string id, [FromBody] EditConnectionInfoCommand command)
        {
            try
            {
                if (!ConnectionUtils.ValidateConnectionString(command.ConnectionString))
                {
                    return BadRequest("Invalid Connection string.");
                }
                else
                {
                    command.ConnectionId = id.ToString();
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConnectionInfo(string id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteConnectionInfoCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet("profiles/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ConnectionInfoResponse>> Get(string id)
        {
            return await _mediator.Send(new GetConnectionInfoByIdQuery(id));
        }

        [HttpGet("users/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ConnectionInfoResponse> GetConnectionInfoByName(string username)
        {
            return await _mediator.Send(new GetConnectionInfoByEmailQuery(username));
        }
    }
}
