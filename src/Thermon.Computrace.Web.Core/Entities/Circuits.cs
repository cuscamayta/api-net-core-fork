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
    public class Circuits:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Segments> Segments { get; set; } = new List<Segments>();

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
    }
}
