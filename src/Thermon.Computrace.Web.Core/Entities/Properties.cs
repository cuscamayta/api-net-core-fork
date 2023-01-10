using Thermon.Computrace.Web.Core.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using Thermon.Computrace.Web.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Thermon.Computrace.Web.Core.Entities
{
    public class Properties
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, ForeignKey("Project")]
        public long ProjectId { get; set; }
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
        public string POAmount { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateDue { get; set; }
        public bool Pipe { get; set; }
        public bool InsulationUnitsImperial { get; set; }
        public bool Imperial { get; set; }
        public bool OtherTypes { get; set; }
        public string TemperatureUnits { get; set; }
        public string CautionLabelInternal { get; set; }
        public string MaxSpiralRadio { get; set; }
        public string CircumFixingType { get; set; }
        public string AluminumType { get; set; }
        public string ElectricalCodes { get; set; }
        public string DefaultTermAllowance { get; set; }
        //public virtual Project Project { get; set; }
    }
}
