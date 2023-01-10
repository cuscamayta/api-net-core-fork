using System;

namespace Thermon.Computrace.Web.Application.Response
{
    public class ProjectResponse : IProjectResponse
    {
        public int ProjectId { get; set; }
        public string Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public string ComputraceVersion { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseLocation { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CircuitLastModified { get; set; }
        public int TotalCircuits { get; set; }
        public int TotalDesignedCircuits { get; set; }
        public string DatabaseType { get; set; }

    }
}
