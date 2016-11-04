using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;

namespace VL.User.Objects
{
    public class Constraints
    {
        public static ModuleReportHelper ReportHelper { set; get; } = new ModuleReportHelper(nameof(VL.User));
    }
}
