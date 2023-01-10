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
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Api;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;

namespace Thermon.Computrace.IntegrationTest.Api
{
    [TestClass]
    public class ProjectApiTest
    {
        private static WebApplicationFactory<Startup> _factory;

        private Mock<IProjectQueryRepository> _projectRepositoryMock;

        private TestServer _testServer;
        protected HttpClient _testClient { get; private set; }
        protected IServiceProvider Services => _testServer.Services;

        private IReadOnlyList<Project> GetMockData()
        {
            return new List<Project>()
            {
                new Project(){

                },
                new Project(){

                },
                new Project(){

                }
            };
        }


        [TestInitialize]
        public void Setup()
        {
            _projectRepositoryMock = new Mock<IProjectQueryRepository>();
            _testServer = new TestServer(
                new WebHostBuilder()
                    .ConfigureTestServices(services =>
                    {
                        services.AddSingleton<IProjectQueryRepository>(_projectRepositoryMock.Object);
                    })
                    .UseStartup<Startup>());
            _testClient = _testServer.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturnSuccessResponse()
        {            
            var response = await _testClient.GetAsync("api/v1/projects/health");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("text/plain; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var message = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("Project Service is Up", message);
        }

        [TestMethod]
        public async Task ShouldReturnAEmptyListOfProjects()
        {
            var response = await _testClient.GetAsync("api/v1/projects");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        [TestMethod]
        public async Task ShouldReturnAListOfProjects()
        {
            _projectRepositoryMock.Setup(mr => mr.GetAllAsync()).Returns(Task.FromResult(GetMockData()));
            var response = await _testClient.GetAsync("api/v1/projects");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Project>>(json);
            Assert.AreEqual(3, result.Count);            
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            _testClient.Dispose();
        }
    }
}
