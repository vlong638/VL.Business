using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;

namespace VL.Spider.Manipulator.Configs
{
    public class ConfigOfSpider:XMLConfigItem, IGeneticCloneable<ConfigOfSpider>
    {
        public string SpiderName { set; get; } = "";
        public ConfigOfRequest RequestConfig { set; get; } = new ConfigOfRequest();
        public ConfigOfProcess ManageConfig { set; get; } = new ConfigOfProcess()
        {
            MaxConnectionNumber = 1,
        };
        public List<IGrabConfig> GrabConfigs { set; get; } = new List<IGrabConfig>();


        public ConfigOfSpider(XElement element):base(element)
        {
        }
        public ConfigOfSpider(string spiderName)
        {
            SpiderName = spiderName;
        }

        public override XElement ToXElement()
        {
            return new XElement(nameof(ConfigOfSpider)
                ,new XAttribute(nameof(SpiderName), SpiderName)
                , RequestConfig.ToXElement()
                , GrabConfigs.Select(c => c.ToXElement())
                );
        }

        public override void LoadXElement(XElement element)
        {
            SpiderName = element.Attribute(nameof(SpiderName)).Value;
            RequestConfig = new ConfigOfRequest(element.Descendants(nameof(ConfigOfRequest)).First());
            GrabConfigs = new List<IGrabConfig>();
            foreach (var grabConfig in element.Descendants(nameof(IGrabConfig)))
            {
                GrabConfigs.Add(IGrabConfig.GetGrabConfig(grabConfig, this));
            }
        }

        public ConfigOfSpider Clone()
        {
            var spider = new ConfigOfSpider(SpiderName);
            spider.RequestConfig = RequestConfig.Clone();
            spider.ManageConfig = ManageConfig.Clone();
            spider.GrabConfigs = new List<IGrabConfig>();
            foreach (var grabConfig in GrabConfigs)
            {
                spider.GrabConfigs.Add(grabConfig.Clone(spider));
            }
            return spider;
        }
    }
    public class ConfigOfSpiders : XMLConfigEntity
    {
        public string LatestSpiderConfigName { set; get; } = "";
        public List<ConfigOfSpider> Configs { set; get; } = new List<ConfigOfSpider>();


        public ConfigOfSpiders(string fileName) : base(fileName)
        {
        }

        protected override void Load(XDocument doc)
        {
            var spiders = doc.Descendants(nameof(ConfigOfSpider));
            foreach (var spider in spiders)
            {
                Configs.Add(new ConfigOfSpider(spider));
            }
            var latestSpiderConfigName = doc.Descendants(nameof(LatestSpiderConfigName)).FirstOrDefault();
            if (latestSpiderConfigName!=null)
            {
                LatestSpiderConfigName = latestSpiderConfigName.Value;
            }
        }
        public override IEnumerable<XElement> ToXElements()
        {
            var configs= Configs.Select(c => c.ToXElement()).ToList();
            configs.Add(new XElement(nameof(LatestSpiderConfigName), LatestSpiderConfigName));
            return configs;
        }
    }
}
