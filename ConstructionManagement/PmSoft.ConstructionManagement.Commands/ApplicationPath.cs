using System.IO;
using System.Windows.Forms;

namespace PmSoft.ConstructionManagement.Commands
{
    /// <summary>
    /// Provides static functions to convert unit
    /// </summary>
    public static class ApplicationPath
    {
        /// <summary>
        /// 获取当前dll所在目录
        /// </summary>
        public static string CurrentPath
        {
            get
            {
                string path;
                ApplicationPath.GetSysDataPath(out path);
                return path;
            }
        }

        /// <summary>
        /// 当前打开文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentPath(Autodesk.Revit.DB.Document doc)
        {
            return doc.PathName.Substring(0, doc.PathName.LastIndexOf(@"\") + 1);
        }

        /// <summary>
        /// 获取当前dll的上级目录
        /// </summary>
        public static string GetParentPathOfCurrent
        {
            get
            {
                string path;
                ApplicationPath.GetParentPath(out path, CurrentPath);
                return path;
            }
        }

        #region
        public static bool GetSysDataPath(out string sSysPath)
        {
            sSysPath = "";
            try
            {
                string currentCommandAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                sSysPath = Path.GetDirectoryName(currentCommandAssemblyPath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取系统路径失败，请重新安装软件!" + ex.Message);
                return false;
            }

            return true;  //当前目录的上一级目录
        }


        /// <summary>
        /// 返回路径的上一级目录
        /// </summary>
        /// <param name="sParentPath"></param>
        /// <returns></returns>
        public static bool GetParentPath(out string sParentPath, string syspath)
        {
            sParentPath = "";
            try
            {
                DirectoryInfo pathinfo = new DirectoryInfo(syspath).Parent;
                sParentPath = Path.GetFullPath(pathinfo.FullName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取系统路径失败，请重新安装软件!" + ex.Message);
                return false;
            }

            return true;  //当前目录的上一级目录
        }

        #endregion
    }
}
