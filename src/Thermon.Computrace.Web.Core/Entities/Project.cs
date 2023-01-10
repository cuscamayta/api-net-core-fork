using Thermon.Computrace.Web.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Thermon.Computrace.Web.Core.Entities
{    
    public class Project : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ProjectId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string ComputraceVersion { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseLocation { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime CircuitLastModified { get; set; }
        public int TotalCircuits { get; set; }
        public int TotalDesignedCircuits { get; set; }
        public string DatabaseType { get; set; }
        public virtual Properties Properties { get; set; }
    }
}
