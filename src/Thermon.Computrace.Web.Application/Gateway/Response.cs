using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Gateway
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public CallContext CallContext { get; set; }
        public Response(HttpStatusCode statusCode, T data, CallContext callContext)
        {
            StatusCode = statusCode;
            Data = data;
            CallContext = callContext;
        }
    }

    public class CallContext
    {
        public string Header { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
