using System;
using System.Xml.Linq;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Objects;
using VL.Common.Protocol.IService;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class GrabConfigOfDynamicList : IGrabConfig
    {
        public GrabConfigOfDynamicList(XElement element, ConfigOfSpider spiderConfig) : base(element, spiderConfig)
        {
        }
        public GrabConfigOfDynamicList(ConfigOfSpider spiderConfig) : base(spiderConfig)
        {
        }

        public override bool CheckAvailable(ILogger logger)
        {
            //TODO
            return true;
        }
        public override EGrabType GrabType
        {
            get
            {
                return EGrabType.DynamicList;
            }
        }

        public override XElement ToXElement()
        {
            return new XElement(nameof(IGrabConfig)
                , new XAttribute(nameof(GrabType), GrabType)
                , new XAttribute(nameof(IsOn), IsOn)
            );
        }
        public override void LoadXElement(XElement element)
        {
            IsOn = Convert.ToBoolean(element.Attribute(nameof(IsOn)).Value);
        }

        public override IGrabConfig Clone(ConfigOfSpider spider)
        {
            return new GrabConfigOfDynamicList(spider)
            {
                IsOn = this.IsOn,
            };
        }
        protected override Result GrabbingContent(string pageStream, string pageName = "")
        {
            throw new NotImplementedException("该类型暂不支持保存于文件的抓取");
        }
        protected override Result GrabbingContent(DbSession session, string pageString, string pageName = "Default")
        {
            throw new NotImplementedException("该类型暂不支持保存于数据库的抓取");
        }
    }
}
