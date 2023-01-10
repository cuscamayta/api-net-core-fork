using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities.Base;

namespace Thermon.Computrace.Web.Core.Entities
{
    public class ConnectionInfo : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ConnectionId { get; set; }
        public Guid UserProfileId { get; set; }
        public string ConnectionName { get; set; }
        public bool Active { get; set; }
        public bool Default { get; set; }
        public string ConnectionString { get; set; }
        public bool MyProjects { get; set; }
        public string UserName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
