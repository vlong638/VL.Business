using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Objects;
using VL.Common.Protocol.IService;
using VL.Spider.Objects.Entities;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class GrabConfigOfStaticList : IGrabConfig
    {
        public string Pattern { set; get; } = "";
        public int IndexOfTitle { set; get; } = 1;
        public int IndexOfURL { set; get; } = 1;
        
        public GrabConfigOfStaticList(XElement element, ConfigOfSpider spiderConfig) : base(element, spiderConfig)
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
                , new XAttribute(nameof(Pattern), Pattern)
                , new XAttribute(nameof(IndexOfTitle), IndexOfTitle)
                , new XAttribute(nameof(IndexOfURL), IndexOfURL)
                );
        }
        public override void LoadXElement(XElement element)
        {
            var attribute = element.Attribute(nameof(IsOn));
            if (attribute != null)
            {
                IsOn = Convert.ToBoolean(attribute.Value);
            }
            attribute = element.Attribute(nameof(Pattern));
            if (attribute!=null)
            {
                Pattern = attribute.Value;
            }
            attribute = element.Attribute(nameof(IndexOfTitle));
            if (attribute != null)
            {
                IndexOfTitle = Convert.ToInt32(attribute.Value);
            }
            attribute = element.Attribute(nameof(IndexOfURL));
            if (attribute != null)
            {
                IndexOfURL = Convert.ToInt32(attribute.Value);
            }
        }
        public override IGrabConfig Clone(ConfigOfSpider spider)
        {
            return new GrabConfigOfStaticList(spider)
            {
                IsOn = this.IsOn,
                Pattern = this.Pattern,
                IndexOfTitle = this.IndexOfTitle,
                IndexOfURL = this.IndexOfURL,
            };
        }
        protected override Result GrabbingContent(string pageStream, string pageName = "")
        {
            throw new NotImplementedException("该类型暂不支持保存于文件的抓取");
        }
        protected override Result GrabbingContent(DbSession session, string pageString, string pageName = "Default")
        {
            //var pattern = @"<a test=a href='(http[\w\:\/\.]+)' target='_blank'>(.{0,100})</a><span> \([\d\/\s\:]+\)</span><span class='star'>";
            //int indexOfTitle = 2;
            //int indexOfURL = 1;
            Regex regex = new Regex(Pattern);
            var matches = regex.Matches(pageString);
            short orderNumber = 1;
            foreach (Match match in matches)
            {
                if (!new TGrabList().Create(session, SpiderConfig.Spider.SpiderId, pageName, orderNumber, match.Groups[IndexOfTitle].Value, match.Groups[IndexOfURL].Value))
                {
                    return new Result(nameof(GrabbingContent)) { ResultCode = EResultCode.Failure, Message = "解析页面数据失败" };
                }
                orderNumber++;
            }
            return new Result(nameof(GrabbingContent)) { ResultCode = EResultCode.Success, Message = "解析页面数据成功,共计" + (orderNumber - 1).ToString() + "项数据" };
        }
    }
}
