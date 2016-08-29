using System;
using System.IO;
using System.Xml.Linq;
using VL.Common.Logger.Objects;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class GrabConfigOfFile : IGrabConfig
    {
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string DirectoryPath { set; get; } = "";
        /// <summary>
        /// 文件名生成的参数
        /// </summary>
        public string FileNameTag { set; get; } = "Default";
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { set; get; } = "";
        //public string FileName
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            fileName = GrabNamingHelper.GetNameForFile(FileNameTag);
        //        }
        //        return fileName;
        //    }
        //    set
        //    {
        //        fileName = value;
        //    }
        //}
        //private string fileName;

        public GrabConfigOfFile(ConfigOfSpider spiderConfig, XElement element) : base(element, spiderConfig)
        {
        }
        public GrabConfigOfFile(ConfigOfSpider spiderConfig) : base(spiderConfig)
        {
        }

        public override bool CheckAvailable(ILogger logger)
        {
            if (string.IsNullOrEmpty(DirectoryPath))
            {
                throw new NotImplementedException("未设置输出的目录位置");
            }
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            return true;
        }
        protected override GrabResult GrabbingContent(string pageContent, string pageName = "")
        {
            string path;
            if (pageName != "")
            {
                path = Path.Combine(DirectoryPath, pageName);
            }
            else
            {
                if (string.IsNullOrEmpty(FileNameTag))
                {
                    throw new NotImplementedException(nameof(FileName) + "和" + nameof(FileNameTag) + "之间至少设置一项值");
                }
                path = Path.Combine(DirectoryPath, string.IsNullOrEmpty(FileName) ? GrabNamingHelper.GetNameForFile(FileNameTag) : FileName);
            }
            File.WriteAllText(path, pageContent);
            return new GrabResult(true, "抓取成功,文件输出于" + path);
        }

        public override EGrabType GetGrabType()
        {
            return EGrabType.File;
        }

        public override XElement ToXElement()
        {
            return new XElement(nameof(IGrabConfig)
                , new XAttribute(nameof(GrabType), GetGrabType())
                , new XAttribute(nameof(IsOn), IsOn)
                , new XAttribute(nameof(DirectoryPath), DirectoryPath)
                , new XAttribute(nameof(FileNameTag), FileNameTag)
                , new XAttribute(nameof(FileName), FileName)
                );
        }
        public override void LoadXElement(XElement element)
        {
            DirectoryPath = element.Attribute(nameof(DirectoryPath)).Value;
            FileNameTag = element.Attribute(nameof(FileNameTag)).Value;
            FileName = element.Attribute(nameof(FileName)).Value;
            IsOn = Convert.ToBoolean(element.Attribute(nameof(IsOn)).Value);
        }
        public override IGrabConfig Clone(ConfigOfSpider spider)
        {
            return new GrabConfigOfFile(spider)
            {
                IsOn = this.IsOn,
                DirectoryPath = this.DirectoryPath,
                FileNameTag = this.FileNameTag,
                FileName = this.FileName,
            };
        }
    }
}
