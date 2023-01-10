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
    public class Items : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShorDescription { get; set; }
        public string CatalogNumber { get; set; }
        public int Quantity { get; set; }
        public string Parts { get; set; }
        public string Units { get; set; }
    }
}
