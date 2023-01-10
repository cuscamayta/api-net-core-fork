using System.Collections.Generic;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Api.Services
{
    public interface IDocumentService
    {
        byte[] GeneratePdfFromString(List<Materials> items);
    }
}
