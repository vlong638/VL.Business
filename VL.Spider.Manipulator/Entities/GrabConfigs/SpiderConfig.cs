using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;

namespace VL.Spider.Manipulator.Entities.GrabConfigs
{
    public class SpiderConfig : XMLConfigEntity
    {
        public SpiderConfig(string fileName) : base(fileName)
        {
        }

        public override IEnumerable<XElement> GetXElements()
        {
            throw new NotImplementedException();
        }

        protected override void Load(XDocument doc)
        {
            throw new NotImplementedException();
        }
    }
}
