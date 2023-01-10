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
using Thermon.Computrace.Web.Application.Response;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Core.Repositories.Query;

namespace Thermon.Computrace.IntegrationTest.Api
{
    [TestClass]
    public class CommentsApiTest
    {
        private Mock<ICommentQueryRepository> _commentsRepositoryMock;
        private Mock<ICommentCommandRepository> _commentsCommandRepositoryMock;

        private TestServer _testServer;
        protected HttpClient _testClient { get; private set; }
        protected IServiceProvider Services => _testServer.Services;

        private IReadOnlyList<Comments> GetMockData()
        {
            return new List<Comments>()
            {
                new Comments(){

                },
                new Comments(){

                },
                new Comments(){

                }
            };
        }

        [TestInitialize]
        public void Setup()
        {
            _commentsRepositoryMock = new Mock<ICommentQueryRepository>();
            _commentsCommandRepositoryMock = new Mock<ICommentCommandRepository>();

            _testServer = new TestServer(
                new WebHostBuilder()
                    .ConfigureTestServices(services =>
                    {
                        services.AddSingleton<ICommentQueryRepository>(_commentsRepositoryMock.Object);
                        services.AddSingleton<ICommentCommandRepository>(_commentsCommandRepositoryMock.Object);
                    })
                    .UseStartup<Startup>());
            _testClient = _testServer.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturnAEmptyListOfComments()
        {
            var response = await _testClient.GetAsync("/api/v1/comments");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        [TestMethod]
        public async Task ShouldReturnAListOfComments()
        {
            _commentsRepositoryMock.Setup(mr => mr.GetAllAsync()).Returns(Task.FromResult(GetMockData()));
            var response = await _testClient.GetAsync("api/v1/comments");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Comments>>(json);
            Assert.AreEqual(3, result.Count);
        }

        [TestCleanup]
        public void ClassCleanup()
        {
            _testClient.Dispose();
        }
    }
}
