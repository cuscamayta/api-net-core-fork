using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Thermon.Computrace.Web.Api.Services;
using Thermon.Computrace.Web.Application.Commands.Project;
using Thermon.Computrace.Web.Application.Gateway;
using Thermon.Computrace.Web.Application.Queries.ConnectionInfo;
using Thermon.Computrace.Web.Application.Queries.Profiles;
using Thermon.Computrace.Web.Application.Queries.Projects;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Api.Controllers
{
    [Route("api/v1/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDocumentService _documentService;
        private readonly IConfiguration _configuration;
        public ProjectController(IMediator mediator, IDocumentService documentService, IConfiguration configuration)
        {
            _mediator = mediator;
            _documentService = documentService;
            _configuration = configuration;
        }

        [HttpGet("health")]
        public async Task<ActionResult> GetHealth()
        {
            return Ok("Project Service is Up");
        }


        //getProjectProperties
        //getProjectBillOfMaterials

        [HttpGet("{name}/detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProjectResponse> GetByName(string name)
        {
            return await _mediator.Send(new GetProjectByNameQuery(name));
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<ProjectInformationDto>>> GetProjects([FromQuery] string connectionId)
        {

            //return await _mediator.Send(new GetProjectAllQuery(connectionId));
            string url = _configuration["Services:DataApiUrl"];
            var connectionStrings = await GetConnectionInformationBasedOnConnectionIds(new List<string>() { connectionId });

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProjectInformationDto>>(new LoginCredentials(), $"/projects/all", HttpVerbs.POST, connectionStrings);

            return response;
        }

        [HttpPost("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<ProjectInformationDto>>> GetProjectsDetail([FromQuery] List<string> connectionIds)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionStrings = await GetConnectionInformationBasedOnConnectionIds(connectionIds);

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProjectInformationDto>>(new LoginCredentials(), $"/projects/all", HttpVerbs.POST, connectionStrings);

            return response;
        }


        [HttpPost("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<List<ProjectDto>>> GetProjectDetails([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];

            var connectionString = string.IsNullOrEmpty(connectionDetail.ConnectionId) ? _configuration["ConnectionStrings:ComputraceDb"]
                                                                                        : (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProjectDto>>(new LoginCredentials(), $"/projects/details", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId.ToLower() });

            return response;
        }

        [HttpGet("{id}/properties/{connectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PropertiesResponse> GetProjectProperties(string connectionId, string id)
        {
            //string url = "http://dev-app-win2019-001.eastus2.cloudapp.azure.com:8082/v1/";
            //var connectionString = @"Data Source=devdata001.southcentralus.cloudapp.azure.com;Initial Catalog=CompuTraceDb;User Id=sa;Password=PasswordIsP@ssw0rd;Persist Security Info=true;";
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionId });

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProjectDto>>(new LoginCredentials(), $"/projects/{id}", HttpVerbs.GET);
            var project = response.Data.FirstOrDefault();

            return new PropertiesResponse()
            {
                AluminumType = project.AluminumTape?.AluminumTapeName,
                ByCustomer = project.ByCustomer,
                ByLocation = project.ByLocation,
                CircumFixingType = project.CircumferentialFixingTape?.CircumferentialFixingTapeName,
                Customer = project.Customer,
                DateDue = project.DateDue,
                DateEntered = project.DateEntered,
                DefaultTermAllowance = project.DefaultTerminationAllowance,
                Designer = project.Designer,
                ElectricalCodes = project.ElectricalStandardsAgency?.AreaName,
                ForCustomer = project.ForCustomer,
                ForLocation = project.ForLocation,
                JobNumber = project.JobNumber,
                Location = project.Location,
                MaxSpiralRadio = project.MaxSpiralRatio,
                POAmount = project.POAmount,
                ProjectId = project.ProjectID,
                ProjectManager = project.ProjectManager,
                ProjectName = project.ProjectName,
                ProjectNumber = project.ProjectNumber,
                PurchaseOrder = project.PurchaseOrder,
                SBU = project.SBU
            };
        }


        [HttpGet("{id}/bomSummary")]
        public async Task<Response<List<ProjectBomPropertiesResponse>>> GetBomSummary([FromBody] ConnectionInformation connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var response = await client.Request<List<ProjectBomPropertiesResponse>>(new LoginCredentials(), $"/projects/bom", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId.ToLower() });

            return response;
        }


        [HttpGet("{projectId}/circuits/{circuitId}/segments/{segmentId}/bom/pdf")]
        public async Task<ActionResult> GetBillOfMaterialsPdf(string projectId, string circuitId, string segmentId)
        {
            var items = CircuitsData.Items.Where(x => x.SegmentId == segmentId).ToList();
            string url = _configuration["Services:DataApiUrl"];

            var connectionString = _configuration["ConnectionStrings:ComputraceDb"];

            var client = new RestClient(url, "none");
            var project = await client.Request<List<ProjectDto>>(new LoginCredentials(), $"/projects/details", HttpVerbs.POST, new { connectionString = connectionString, projectId = projectId });

            string reportname = $"bill_of_materials_{Guid.NewGuid():N}.xlsx";
            var circuit = project.Data.FirstOrDefault().Circuits.FirstOrDefault(x => x.CircuitID == Guid.Parse(circuitId));

            var segments = circuit.Connections.SelectMany(x => x.Segments).Where(x => x.SegmentID == Guid.Parse(segmentId));

            var billOfMaterials = segments.SelectMany(x => x.BillOfMaterialsEntries);

            var listToExport = billOfMaterials.Select(x => new Materials()
            {
                CatalogNumber = x.CatalogNumber,
                Description = x.Description,
                ItemNumber = x.ItemNumber,
                PartNumber = x.PartNumber,
                Quantity = x.Quantity,
                Units = x.Unit
            }).ToList();

            var pdf2 = _documentService.GeneratePdfFromString(listToExport);
            Stream stream = new MemoryStream(pdf2);
            return new FileStreamResult(stream, "application/pdf");
        }

        [HttpGet("{projectId}/circuits/{circuitId}/segments/{segmentId}/bom/export/pdf")]
        public async Task<ActionResult> GetBillOfMaterialsPdfFile(string projectId, string circuitId, string segmentId)
        {
            var items = CircuitsData.Items.Where(x => x.SegmentId == segmentId).ToList();
            string url = _configuration["Services:DataApiUrl"];// "http://dev-app-win2019-001.eastus2.cloudapp.azure.com:8082/v1/";

            var connectionString = _configuration["ConnectionStrings:ComputraceDb"];

            var client = new RestClient(url, "none");
            var project = await client.Request<List<ProjectDto>>(new LoginCredentials(), $"/projects/details", HttpVerbs.POST, new { connectionString = connectionString, projectId = projectId });

            string reportname = $"bill_of_materials_{Guid.NewGuid():N}.xlsx";
            var circuit = project.Data.FirstOrDefault().Circuits.FirstOrDefault(x => x.CircuitID == Guid.Parse(circuitId));

            var segments = circuit.Connections.SelectMany(x => x.Segments).Where(x => x.SegmentID == Guid.Parse(segmentId));

            var billOfMaterials = segments.SelectMany(x => x.BillOfMaterialsEntries);

            var listToExport = billOfMaterials.Select(x => new Materials()
            {
                CatalogNumber = x.CatalogNumber,
                Description = x.Description,
                ItemNumber = x.ItemNumber,
                PartNumber = x.PartNumber,
                Quantity = x.Quantity,
                Units = x.Unit
            }).ToList();


            var pdfFile = _documentService.GeneratePdfFromString(listToExport);
            return File(pdfFile, "application/octet-stream", "BillOfMaterials.pdf");
        }


        [HttpPost("export/bom/excel")]
        public async Task<ActionResult> GetBillOfMaterialsExcelFile([FromBody] ConnectionDetail connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];

            var connectionString = (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var project = await client.Request<List<ProjectDto>>(new LoginCredentials(), $"/projects/details", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            string reportname = $"bill_of_materials_{Guid.NewGuid():N}.xlsx";
            var circuit = project.Data.FirstOrDefault().Circuits.FirstOrDefault(x => x.CircuitID == Guid.Parse(connectionDetail.CircuitId));

            var segments = circuit.Connections.SelectMany(x => x.Segments).Where(x => x.SegmentID == Guid.Parse(connectionDetail.SegmentId));

            var billOfMaterials = segments.SelectMany(x => x.BillOfMaterialsEntries);

            var listToExport = billOfMaterials.Select(x => new Materials()
            {
                CatalogNumber = x.CatalogNumber,
                Description = x.Description,
                ItemNumber = x.ItemNumber,
                PartNumber = x.PartNumber,
                Quantity = x.Quantity,
                Units = x.Unit
            }).ToList();

            var exportbytes = ExcelService.ExporttoExcel<Materials>(listToExport, reportname);
            return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportname);
        }

        [HttpPost("export")]
        public async Task<ActionResult> GetProjectExport([FromBody] ConnectionDetail connectionDetail)
        {
            string url = _configuration["Services:DataApiUrl"];
            var connectionString = (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionDetail.ConnectionId })).FirstOrDefault();

            var client = new RestClient(url, "none");
            var project = await client.Request<string>(new LoginCredentials(), $"/export", HttpVerbs.POST, new { connectionString = connectionString, projectId = connectionDetail.ProjectId });

            var fileName = "project.json";
            var mimeType = "text/plain";
            var fileBytes = Encoding.ASCII.GetBytes(project.Data);
            return new FileContentResult(fileBytes, mimeType)
            {
                FileDownloadName = fileName
            };
        }

        [HttpPost, Route("import")]
        public async Task<ActionResult> ImportProject(string connectionId, string userName)
        {
            var file = Request.Form.Files[0];
            var connectionString = (await GetConnectionStringsBasedOnConnectionIds(new List<string>() { connectionId })).FirstOrDefault();

            if (file.Length > 0)
            {
                using (Stream stream = file.OpenReadStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string jsontToImport = await reader.ReadToEndAsync();

                    string url = _configuration["Services:DataApiUrl"];
                    var client = new RestClient(url, "none");
                    var data = new { connectionString = connectionString, JsonToImport = jsontToImport, UserName = userName };
                    var response = await client.Request<object>(new LoginCredentials(), $"/ /import", HttpVerbs.POST, data);
                    return Ok();
                }
            }
            return BadRequest();
        }

        private async Task<List<string>> GetConnectionStringsBasedOnConnectionIds(List<string> connectionIds)
        {
            var connections = await _mediator.Send(new GetConnectionsInfoByIdsQuery(connectionIds));
            return connections.Select(x => x.ConnectionString).ToList();
        }
        private async Task<List<ConnectionDescription>> GetConnectionInformationBasedOnConnectionIds(List<string> connectionIds)
        {
            var connections = await _mediator.Send(new GetConnectionsInfoByIdsQuery(connectionIds));
            return connections.Select(x => new ConnectionDescription(x.ConnectionId, x.ConnectionString)).ToList();
        }

    }
}
