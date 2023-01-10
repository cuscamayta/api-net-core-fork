using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Commands.Profile;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Api.Controllers
{
    [Route("api/v1/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProfileResponse>> CreateProfile([FromBody] CreateProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditProfile(string id, [FromBody] EditProfileCommand command)
        {
            try
            {
                if (command.ProfileId == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile(string id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteProfileCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProfileResponse> Get(string id)
        {
            return await _mediator.Send(new GetProfileByIdQuery(id));
        }

        [HttpGet("users/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProfileResponse> GetByName(string email)
        {
            return await _mediator.Send(new GetProfileByEmailQuery(email));
        }
    }
}
