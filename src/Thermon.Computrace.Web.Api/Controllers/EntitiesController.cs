using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Application.Gateway;
using MediatR;
using Thermon.Computrace.Web.Application.Queries.ConnectionInfo;
using System.Linq;

namespace Thermon.Computrace.Web.Api.Controllers
{

    [Route("api/v1/projects")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public EntitiesController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("insulationtypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<InsulationType>>> GetProjectInsulationTypes([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = string.IsNullOrEmpty(connectionDetail.ConnectionId) ? _configuration["ConnectionStrings:ComputraceDb"]
                                                                                       : (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<InsulationType>>(new LoginCredentials(), $"/projects/entities/insulationtypes", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            return response;
        }

        [HttpPost("heatsinks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<HeatSink>>> GetProjectHeatSinks([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = string.IsNullOrEmpty(connectionDetail.ConnectionId) ? _configuration["ConnectionStrings:ComputraceDb"] 
                                                                                       : (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<HeatSink>>(new LoginCredentials(), $"/projects/entities/heatsinks", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            return response;
        }

        [HttpPost("pipetypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<PipeType>>> GetProjectPipeTypess([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = string.IsNullOrEmpty(connectionDetail.ConnectionId) ? _configuration["ConnectionStrings:ComputraceDb"]
                                                                                       : (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<PipeType>>(new LoginCredentials(), $"/projects/entities/pipetypes", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            return response;
        }

        [HttpPost("processfluid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<ProcessFluid>>> GetProjectProcessFluid([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = string.IsNullOrEmpty(connectionDetail.ConnectionId) ? _configuration["ConnectionStrings:ComputraceDb"] 
                                                                                       : (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProcessFluid>>(new LoginCredentials(), $"/projects/entities/processfluid", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            return response;
        }

        private async Task<List<string>> GetConnectionStringsBasedOnConnectionIds(List<string> connectionIds)
        {
            var connections = await _mediator.Send(new GetConnectionsInfoByIdsQuery(connectionIds));
            return connections.Select(x => x.ConnectionString).ToList();
        }
    }
}
