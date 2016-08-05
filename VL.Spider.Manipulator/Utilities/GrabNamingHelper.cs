using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Spider.Manipulator.Utilities
{
    public class GrabNamingHelper
    {
        public static string GetNameForFile(string tag)
        {
            return tag + DateTime.Now.ToString("hhMMss") + ".txt";
        }
    }
}
