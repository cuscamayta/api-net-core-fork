using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Api;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using System.Net.Http;
using System.Net.Http.Json;

namespace Thermon.Computrace.IntegrationTest.CompuTrace.Data.Api.Tests
{
    [TestClass]
    public class CompuTraceDataTests
    {

        public class ProjectItem
        {
            private readonly string _url = "https://localhost:44346/v1/";

            /// <summary>
            /// 
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
                            Console.WriteLine($"{ d.ProjectName} ");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
                    }
                }

                return items;
            }

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

            public Thermon.Computrace.Web.Core.Entities.Project MapTo(long id)
            {
                return new Thermon.Computrace.Web.Core.Entities.Project
                {
                    ProjectId = id,
                    ProjectOwner = ProjectOwnerName,
                    Name = ProjectName,
                    Number = ProjectNumber,
                    ComputraceVersion = CompuTraceVersion,
                    DatabaseVersion = DatabaseVersion,
                    DatabaseName = DatabaseName,
                    DatabaseLocation = DatabaseLocation,
                    DatabaseConnectionString = DatabaseConnectionString,
                    CircuitLastModified = CircuitLastModified,
                    TotalCircuits = TotalCircuits,
                    TotalDesignedCircuits = TotalDesignedCircuits,
                    DatabaseType = DatabaseType
                };
            }
        }
        
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void GetProjectItemsFromProjectItemShouldPass()
        {            
            var baseUrl = "https://localhost:44346/v1/";
            var projectItem = new ProjectItem(baseUrl);
            var projectItems = projectItem.GetAllAsync(string.Empty);

            projectItems.Wait();

            Assert.IsNotNull(projectItems.Result);
        }

        //GetItemsByConnectionAsync
        [TestMethod]
        public void GetProjectItemsFromProjectItemByConnectionShouldPass()
        {
            var notExpected = 0;
            var actual = 0;
            var connectionString = @"Data Source=devdata001.southcentralus.cloudapp.azure.com;Initial Catalog=CompuTraceDb;User Id=computrace;Password=DefaultSQLServerP@ssw0rd;Persist Security Info=true;";

            var baseUrl = "https://localhost:44346/v1/";
            var projectItem = new ProjectItem(baseUrl);
            var projectItems = projectItem.GetItemsByConnectionAsync(connectionString);

            projectItems.Wait();

            var items = projectItems?.Result;
            Assert.IsNotNull(items);
            actual = items.Count();

            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod]
        public void MapProjectItemsToProjectShouldPass()
        {
            var notExpected = 0;
            var actual = 0;
            var connectionString = @"Data Source=devdata001.southcentralus.cloudapp.azure.com;Initial Catalog=CompuTraceDb;User Id=computrace;Password=DefaultSQLServerP@ssw0rd;Persist Security Info=true;";

            var baseUrl = "https://localhost:44346/v1/";
            var projectItem = new ProjectItem(baseUrl);
            var projectItems = projectItem.GetItemsByConnectionAsync(connectionString);

            projectItems.Wait();

            var items = projectItems?.Result;
            Assert.IsNotNull(items);

            long id = 0;
            var mappedItems = items.Select(i => i.MapTo(++id)).ToList();

            actual = mappedItems.Count();

            Assert.AreNotEqual(notExpected, actual);
        }

    }
}
