using Thermon.Computrace.Web.Core.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using Thermon.Computrace.Web.Common.Enums;

namespace Thermon.Computrace.Web.Core.Entities
{
    public class ProjectUnits
    {
        public bool Pipe { get; set; }
        public bool InsulationUnitsImperial { get; set; }
        public bool Imperial { get; set; }
        public bool OtherTypes { get; set; }
    }
}
