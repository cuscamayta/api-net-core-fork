using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Response
{
    public class PropertiesResponse
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public string ForCustomer { get; set; }
        public string ForLocation { get; set; }
        public string ByCustomer { get; set; }
        public string ByLocation { get; set; }
        public string ProjectManager { get; set; }
        public string Designer { get; set; }
        public string JobNumber { get; set; }
        public string SBU { get; set; }
        public string PurchaseOrder { get; set; }
        public decimal? POAmount { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateDue { get; set; }
        public bool Pipe { get; set; }
        public bool InsulationUnitsImperial { get; set; }
        public bool Imperial { get; set; }
        public bool OtherTypes { get; set; }
        public string CuationLabelInternal { get; set; }
        public double MaxSpiralRadio { get; set; }
        public string CircumFixingType { get; set; }
        public string AluminumType { get; set; }
        public string ElectricalCodes { get; set; }
        public double DefaultTermAllowance { get; set; }        
    }
}
