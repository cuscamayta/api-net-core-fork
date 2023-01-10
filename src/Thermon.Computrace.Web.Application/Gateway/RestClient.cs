using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Gateway
{
    public class RestClient
    {
        string _basePath = string.Empty;
        string _typeAuthorization = string.Empty;

        public RestClient(string basePath, string typeAuthorization)
        {
            _basePath = basePath;
            _typeAuthorization = typeAuthorization;
        }

        public async Task<Response<T>> Request<T>(LoginCredentials credentials, string path, HttpVerbs type, object model = null)
            where T : class
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(_typeAuthorization, GenerateCredentialsOnBase64(credentials));

                string contentRequest = model != null ? JsonConvert.SerializeObject(model) : string.Empty;
                var response = await DoRequest<T>(path, type, contentRequest, client);

                string resultContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var resultText = JsonConvert.DeserializeObject(resultContent, typeof(T)) as T;
                    return new Response<T>(HttpStatusCode.OK, resultText, new CallContext() { Request = contentRequest, Response = resultContent });
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new Response<T>(HttpStatusCode.Unauthorized, null, new CallContext() { Request = contentRequest, Response = resultContent });
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new Response<T>(HttpStatusCode.BadRequest, null, new CallContext() { Request = contentRequest, Response = resultContent });
                }

                throw new ApplicationException(resultContent);
            }
        }

        private async Task<HttpResponseMessage> DoRequest<T>(string path, HttpVerbs type, string content, HttpClient client) where T : class
        {
            HttpResponseMessage response = new HttpResponseMessage();
            client.Timeout = Timeout.InfiniteTimeSpan;

            switch (type)
            {
                case HttpVerbs.POST:
                    response = await client.PostAsync($"{_basePath}{path}",
                        new StringContent(content, Encoding.UTF8, "application/json"));
                    break;
                case HttpVerbs.PUT:
                    response = await client.PutAsync($"{_basePath}{path}",
                        new StringContent(content, Encoding.UTF8, "application/json"));
                    break;
                case HttpVerbs.GET:
                    response = await client.GetAsync($"{_basePath}{path}");
                    break;
            }

            return response;
        }

        private string GenerateCredentialsOnBase64(LoginCredentials credentials)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{credentials.UserName}:{credentials.Password}");
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }

    /*
     
     */

    public class LoginCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCredentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public LoginCredentials()
        {
        }
    }

    public enum HttpVerbs
    {
        POST,
        PUT,
        GET,
        DELETE
    }
}
