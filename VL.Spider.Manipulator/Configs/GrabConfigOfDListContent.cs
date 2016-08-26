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
    public class GrabConfigOfDListContent : IGrabConfig
    {
        public GrabConfigOfDListContent(ConfigOfSpider spiderConfig, XElement element) : base(element, spiderConfig)
        {
        }
        public GrabConfigOfDListContent(ConfigOfSpider spiderConfig) : base(spiderConfig)
        {
        }

        public override bool CheckAvailable(ILogger logger)
        {
            //TODO
            return true;
        }
        protected override GrabResult GrabbingContent(string pageContent, string pageName = "")
        {
            //TODO
            return new GrabResult(false);
        }
        public override EGrabType GetGrabType()
        {
            return EGrabType.DListContent;
        }
        public override XElement ToXElement()
        {
            return new XElement(nameof(IGrabConfig)
                , new XAttribute(nameof(GrabType), GetGrabType())
                , new XAttribute(nameof(IsOn), IsOn)
            );
        }
        public override void LoadXElement(XElement element)
        {
            IsOn = Convert.ToBoolean(element.Attribute(nameof(IsOn)).Value);
        }

        public override IGrabConfig Clone(ConfigOfSpider spider)
        {
            return new GrabConfigOfDListContent(spider)
            {
                IsOn = this.IsOn,
            };
        }
    }
}
