using System;
using System.IO;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Entities.GrabConfigs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class FileGrabConfig : HTTPGrabConfig
    {
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string DirectoryName { set; get; }
        public string FileNameTag { set; get; } = "Default";
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileName
        {
            set
            {
                fileName = value;
            }
            get
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = GrabNamingHelper.GetNameForFile(FileNameTag);
                }
                return fileName;
            }
        }
        public string fileName;

        public override void CheckAvailable()
        {
            if (string.IsNullOrEmpty(DirectoryName))
            {
                throw new NotImplementedException("未设置输出的目录位置");
            }
            if (string.IsNullOrEmpty(FileName))
            {
                throw new NotImplementedException("未设置输出的文件名称");
            }
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }
        }
        protected override void GrabbingContent(string pageContent)
        {
            string path = Path.Combine(DirectoryName, FileName);
            File.WriteAllText(path, pageContent);
        }
    }
}
