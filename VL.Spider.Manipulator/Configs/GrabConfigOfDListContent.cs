using System;
using System.IO;
using System.Xml.Linq;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class GrabConfigOfDListContent : IGrabConfig
    {
        public GrabConfigOfDListContent(XElement element) : base(element)
        {
        }
        public GrabConfigOfDListContent()
        {
        }

        public override bool CheckAvailable()
        {
            //TODO
            return true;
        }
        protected override void GrabbingContent(string pageContent)
        {
            //TODO
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
    }
}
