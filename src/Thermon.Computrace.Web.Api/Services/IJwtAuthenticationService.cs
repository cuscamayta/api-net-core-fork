namespace Thermon.Computrace.Web.Api.Services
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
    }
}
