using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Response
{
    public class ConnectionInfoResponse
    {
        public string ConnectionId { get; set; }
        public string UserProfileId { get; set; }
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
