using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.Logger.Objects;

namespace VL.Spider.Manipulator.Configs
{
    public interface IConfig
    {
        bool CheckAvailable(ILogger logger);
    }
}
