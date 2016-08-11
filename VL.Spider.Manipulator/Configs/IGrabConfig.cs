using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;

namespace VL.Spider.Manipulator.Configs
{
    public enum EGrabType
    {
        /// <summary>
        /// 全文件保存
        /// </summary>
        File,
        /// <summary>
        /// 静态页面列表项
        /// </summary>
        SListContent,
        /// <summary>
        /// 动态页面列表项
        /// </summary>
        DListContent
    }
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public abstract class IGrabConfig : XMLConfigItem,IConfig
    {
        public static IGrabConfig GetGrabConfig(XElement element)
        {
            EGrabType grabType = (EGrabType)Enum.Parse(typeof(EGrabType), element.Attribute(nameof(GrabType)).Value);
            switch (grabType)
            {
                case EGrabType.File:
                    return new GrabConfigOfFile(element);
                case EGrabType.SListContent:
                    return new GrabConfigOfSListContent(element);
                case EGrabType.DListContent:
                    return new GrabConfigOfDListContent(element);
                default:
                    throw new NotImplementedException("暂未实现该类型的抓取配置" + grabType);
            }
        }
        public static IGrabConfig GetGrabConfig(EGrabType grabType)
        {
            switch (grabType)
            {
                case EGrabType.File:
                    return new GrabConfigOfFile();
                case EGrabType.SListContent:
                    return new GrabConfigOfSListContent();
                case EGrabType.DListContent:
                    return new GrabConfigOfDListContent();
                default:
                    throw new NotImplementedException("暂未实现该类型的抓取配置" + grabType);
            }
        }


        public IGrabConfig()
        {
        }
        public IGrabConfig(XElement element) : base(element)
        {
        }

        public bool IsOn { set; get; }
        public abstract bool CheckAvailable();
        public string GrabType { get { return GetGrabType().ToString(); } }
        public abstract EGrabType GetGrabType();

        public void StartGrabbing(ConfigOfRequest requestConfig)
        {
            if (!IsOn)
                return;
            //校验
            if (!CheckAvailable())
            {
                throw new NotImplementedException("校验未通过,抓取已终止");
            }
            //抓取内容
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestConfig.URL);
            request.Method = requestConfig.Method;
            request.UserAgent = requestConfig.UserAgent;
            using (WebResponse response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                GrabbingContent(reader.ReadToEnd());
            }
        }
        protected abstract void GrabbingContent(string pageContent);
    }
}
