using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command.Base;

namespace Thermon.Computrace.Web.Core.Repositories.Command
{
    public interface IProfileCommandRepository:ICommandRepository<Profiles>
    {
    }
}
