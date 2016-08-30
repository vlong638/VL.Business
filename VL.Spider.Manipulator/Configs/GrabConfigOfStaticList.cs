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
    public class GrabConfigOfStaticList : IGrabConfig
    {
        public GrabConfigOfStaticList(ConfigOfSpider spiderConfig, XElement element) : base(element, spiderConfig)
        {
        }
        public GrabConfigOfStaticList(ConfigOfSpider spiderConfig) : base(spiderConfig)
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
                return EGrabType.StaticList;
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
            return new GrabConfigOfStaticList(spider)
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
            //<a test="a" href='http://business.sohu.com/20160825/n465882932.shtml' target='_blank'>干货！2016新成立基金破千及规模排名</a><span> (08/25 09:10)</span><span class='star'>


            throw new NotImplementedException("该类型暂不支持保存于数据库的抓取");
        }
    }
}
