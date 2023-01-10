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
    public class Comments : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }        
        public string Version { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
    }
}