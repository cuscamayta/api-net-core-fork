using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thermon.Computrace.Web.Core.Entities.Base
{
    // Base entity or auditable entity
    public class BaseEntity
    {       
        public DateTime CreatedDate { get; set; }

        public DateTime DateModified { get; private set; }

        public BaseEntity()
        {
            this.DateModified = DateTime.Now;
            this.CreatedDate = DateTime.Now;
        }
    }
}
