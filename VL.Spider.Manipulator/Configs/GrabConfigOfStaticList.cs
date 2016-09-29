using System;
using System.Collections.Generic;
using System.IO;
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
        public bool IsGrabDetail { set; get; } = false;
        public string DetailOutputDirectoryPath { set; get; } = "";

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
        public override EGrabType GetGrabType()
        {
            return EGrabType.StaticList;
        }

        public override XElement ToXElement()
        {
            return new XElement(nameof(IGrabConfig)
                , new XAttribute(nameof(EGrabType), GetGrabType())
                , new XAttribute(nameof(IsOn), IsOn)
                , new XAttribute(nameof(Pattern), Pattern)
                , new XAttribute(nameof(IndexOfTitle), IndexOfTitle)
                , new XAttribute(nameof(IndexOfURL), IndexOfURL)
                , new XAttribute(nameof(IsGrabDetail), IsGrabDetail)
                , new XAttribute(nameof(DetailOutputDirectoryPath), DetailOutputDirectoryPath)
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
            if (attribute != null)
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
            attribute = element.Attribute(nameof(IsGrabDetail));
            if (attribute != null)
            {
                IsGrabDetail = Convert.ToBoolean(attribute.Value);
            }
            attribute = element.Attribute(nameof(DetailOutputDirectoryPath));
            if (attribute != null)
            {
                DetailOutputDirectoryPath = attribute.Value;
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
                IsGrabDetail = this.IsGrabDetail,
                DetailOutputDirectoryPath = this.DetailOutputDirectoryPath,
            };
        }
        public override string GetPageNameWhileEmptyOrNull(string issueName)
        {
            throw new NotImplementedException("StaticList 的期号必为外界生成,程序存在异常");
        }
        public override Result GrabContent(DbSession session, string pageString, string issueName)
        {
            Regex regex = new Regex(Pattern);
            var matches = regex.Matches(pageString);
            short orderNumber = 1;
            foreach (Match match in matches)
            {
                var title = match.Groups[IndexOfTitle].Value;
                var url = match.Groups[IndexOfURL].Value;
                var detailRequestConfig = SpiderConfig.RequestConfig.Clone();
                detailRequestConfig.URLStrategy = URLStrategy.Default;
                detailRequestConfig.URL = url;
                var detailGrabConfig = new GrabConfigOfFile(SpiderConfig) { IsOn = true, DirectoryPath = DetailOutputDirectoryPath, FileName = issueName + "_" + orderNumber + ".xml" };
                if (detailGrabConfig.OnGrabFinish==null)
                {
                    detailGrabConfig.OnGrabFinish += this.OnGrabFinish;
                }
                var detailGrabResult = detailGrabConfig.StartGrabbing(detailRequestConfig);
                switch (new TGrabList().Create(session, SpiderConfig.Spider.SpiderId, issueName, orderNumber, title, url, detailGrabResult ? Path.Combine(DetailOutputDirectoryPath, detailGrabConfig.FileName) : ""))
                {
                    case TGrabList.CreateGrabListResult.Success:
                        break;
                    case TGrabList.CreateGrabListResult.DbOperationFailed:
                        return new Result(nameof(GrabContent)) { ResultCode = EResultCode.Failure, Message = "插入GrabList数据失败" };
                    case TGrabList.CreateGrabListResult.Existed:
                        return new Result(nameof(GrabContent)) { ResultCode = EResultCode.Failure, Message = "GrabList数据已存在" };
                    default:
                        throw new NotImplementedException("未实现对该CreateGrabListResult的处理");
                }
                orderNumber++;
            }
            return new Result(nameof(GrabContent)) { ResultCode = orderNumber == 0 ? EResultCode.Failure : EResultCode.Success, Message = "解析页面数据结束,共计" + (orderNumber - 1).ToString() + "项数据" };
        }
    }
}
