using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Spider.Manipulator.Utilities
{
    /// <summary>
    /// 异常处理帮助类
    /// </summary>
    public class ExceptionHelper
    {
        public static void DoWhileResultCodeHandlerNotImplemented()
        {
            throw new NotImplementedException("暂未支持该结果码的处理");
        }
        public static void DoWhileFunctionNotImplemented()
        {
            throw new NotImplementedException("该功能暂未实现");
        }
    }
}
