using System;

namespace Thermon.Computrace.Web.Application.Response
{
    public interface IProjectResponse
    {
        DateTime CircuitLastModified { get; set; }
        string ComputraceVersion { get; set; }
        DateTime CreatedDate { get; set; }
        string DatabaseConnectionString { get; set; }
        string DatabaseLocation { get; set; }
        string DatabaseName { get; set; }
        string DatabaseType { get; set; }
        string DatabaseVersion { get; set; }
        DateTime DateModified { get; set; }
        string Name { get; set; }
        string Number { get; set; }
        int ProjectId { get; set; }
        string ProjectOwner { get; set; }
        int TotalCircuits { get; set; }
        int TotalDesignedCircuits { get; set; }
    }
}