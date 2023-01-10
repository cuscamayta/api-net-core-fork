﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Application.Commands.Profile
{
    public class EditConnectionInfoCommand : IRequest<ConnectionInfoResponse>
    {
        public string ConnectionId { get; set; }
        public string UserProfileId { get; set; }
        public string ConnectionName { get; set; }
        public bool Active { get; set; }
        public bool Default { get; set; }
        public string ConnectionString { get; set; }
        public bool MyProjects { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }

        public EditConnectionInfoCommand()
        {
            CreatedDate = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}
