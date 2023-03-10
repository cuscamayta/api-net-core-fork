using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Common.Extensions;

namespace Thermon.CompuTrace.Data.Gateway
{

    /// <summary>
    /// Thermon.CompuTrace.Data.API ProjectItem DTO and mapper for <see cref="Computrace.Web.Core.Entities.Project"/>
    /// </summary>
    public partial class ProjectItem
    {
        private readonly string _url = "https://localhost:44346/v1/";

        /// <summary>
        /// The <paramref name="baseUrl"/> of the API to retrieve Thermon.CompuTrace.Data.API <see cref="ProjectItem"/>s
        /// </summary>
        public ProjectItem(string baseUrl)
        {
            _url = baseUrl;
        }

        public string ProjectID { get; set; }
        public int projectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectOwnerName { get; set; }
        public DateTime ProjectLastModified { get; set; }
        public DateTime CircuitLastModified { get; set; }
        public int TotalCircuits { get; set; }
        public int TotalDesignedCircuits { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseLocation { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseType { get; set; }
        public string CompuTraceVersion { get; set; }

        /// <summary>
        /// Returns just the default database information for a user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<ProjectItem>> GetAllAsync(string userName)
        {
            List<ProjectItem> items = new List<ProjectItem>();
            string urlRoute = "projects";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                HttpResponseMessage response = await client.GetAsync(urlRoute);

                if (response.IsSuccessStatusCode)
                {
                    // Parse response body.
                    //items = await response.Content.ReadFromJsonAsync<List<ProjectItem>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll

                    var jsonItems = await response.Content.ReadAsStringAsync();  //Make sure to add a reference to System.Net.Http.Formatting.dll

                    items = JsonConvert.DeserializeObject<List<ProjectItem>>(jsonItems) ?? items;

                    foreach (var d in items)
                    {
                        Console.WriteLine($"{d.ProjectName} ");
                    }
                }
                else
                {
                    Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
                }
            }

            return items;
        }

        /// <summary>
        /// Calls the CompuTrace.Data.API to retrieve a list of <see cref="ProjectItem"/>s
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>List of <see cref="ProjectItem"/></returns>
        public virtual async Task<IEnumerable<ProjectItem>> GetItemsByConnectionAsync(string connectionString)
        {
            List<ProjectItem> items = new List<ProjectItem>();
            string urlRoute = "projects/connect";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var itemsRequest = new { connectionString = connectionString };

                HttpResponseMessage response = await client.PostAsJsonAsync(urlRoute, itemsRequest);

                if (response.IsSuccessStatusCode)
                {
                    // Parse response body.                        
                    var jsonItems = await response.Content.ReadAsStringAsync();

                    items = JsonConvert.DeserializeObject<List<ProjectItem>>(jsonItems) ?? items;

                    foreach (var d in items)
                    {
                        d.DatabaseConnectionString = connectionString;
                        Console.WriteLine($"{d.ProjectName} ");
                    }
                }
                else
                {
                    Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
                }
            }

            return items;
        }

        /// <summary>
        /// Maps a ProjectItem to a Thermon.Computrace.Web.Core.Entities.Project, using the <paramref name="id"/> for the entity's ProjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Thermon.Computrace.Web.Application.Response.IProjectResponse MapTo(int id)
        {
            return new Thermon.Computrace.Web.Application.Response.ProjectResponse
            {
                ProjectId = id,
                ProjectOwner = ProjectOwnerName,
                Id= ProjectID,
                Name = ProjectName,
                Number = ProjectNumber,
                ComputraceVersion = CompuTraceVersion,
                DatabaseVersion = DatabaseVersion,
                DatabaseName = DatabaseName,
                DatabaseLocation = DatabaseLocation,
                DatabaseConnectionString = DatabaseConnectionString.ToAESEncryption(),
                CircuitLastModified = CircuitLastModified,
                TotalCircuits = TotalCircuits,
                TotalDesignedCircuits = TotalDesignedCircuits,
                DatabaseType = DatabaseType
            };
        }
    }
}
