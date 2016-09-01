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
    public class GrabConfigOfDetail : IGrabConfig
    {

        public GrabConfigOfDetail(ConfigOfSpider spiderConfig, XElement element) : base(element, spiderConfig)
        {
        }
        public GrabConfigOfDetail(ConfigOfSpider spiderConfig) : base(spiderConfig)
        {
        }

        public override bool CheckAvailable(ILogger logger)
        {
            //TODO
            return true;
        }
        public override EGrabType GetGrabType()
        {
            return EGrabType.Detail;
        }

        public override XElement ToXElement()
        {
            return new XElement(nameof(IGrabConfig)
                , new XAttribute(nameof(EGrabType), GetGrabType())
                , new XAttribute(nameof(IsOn), IsOn)
                );
        }
        public override void LoadXElement(XElement element)
        {
            if (element.Attribute(nameof(IsOn)) != null)
            {
                IsOn = Convert.ToBoolean(element.Attribute(nameof(IsOn)).Value);
            }
        }
        public override IGrabConfig Clone(ConfigOfSpider spider)
        {
            return new GrabConfigOfStaticList(spider)
            {
                IsOn = this.IsOn,
            };
        }
        public override string GetPageNameWhileEmptyOrNull(string issueName)
        {
            throw new NotImplementedException("Detail 的期号必为外界生成,程序存在异常");
        }
        public override Result GrabContent(DbSession session, string pageString, string issueName)
        {
            throw new NotImplementedException("该功能暂未实现");
        }
    }
}
