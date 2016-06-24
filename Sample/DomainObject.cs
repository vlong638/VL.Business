using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class DomainObject
    {
        #region Outer Subject Function
        //外部 主观 行为
        //总是表述我要做什么
        //我做的怎么样了
        #endregion

        #region Outer Object Function
        //外部 客观 行为
        //总是表述别人想了解我的什么
        #endregion

        #region Inner Function
        //内部 行为
        //总是为外部行为提供内部支持
        #endregion
    }
}
