using System.Collections.Generic;
using System.Linq;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Entities
{
    public class AnalizeResult
    {
        public AnalizeResult(string nodeCode)
        {
            NodeCode = nodeCode;
        }

        public string NodeCode { set; get; }
        public bool IsCondition1Error { set; get; }
        public bool IsCondition2Error { set; get; }
        public bool IsCondition3Error { set; get; }
    }
    public class AnalizeResultCollection
    {
        public List<AnalizeResult> Data { set; get; } = new List<AnalizeResult>();
        public AnalizeResult this[string nodeCode]
        {
            get
            {
                var data = Data.FirstOrDefault(c => c.NodeCode == NodeCode);
                if (data == null)
                {
                    data = new AnalizeResult(nodeCode);
                    Data.Add(data);
                }
                return data;
            }
        }
        public string NodeCode { set; get; }
        public bool IsCondition1Error { set; get; }
        public bool IsCondition2Error { set; get; }
        public bool IsCondition3Error { set; get; }
    }
}
