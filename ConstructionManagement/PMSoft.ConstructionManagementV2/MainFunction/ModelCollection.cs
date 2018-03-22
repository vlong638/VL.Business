using Autodesk.Revit.DB;
using PmSoft.Common.RevitClass.VLUtils;

namespace PMSoft.ConstructionManagementV2
{
    /// <summary>
    /// Model数据集合
    /// </summary>
    public class CMModelCollection : VLModelCollection<CMModel>
    {
        public CMModelCollection(string data) : base(data)
        {
        }

        public void Save(Document doc)
        {
            CMContext.SaveCollection(doc);
        }
        public void Load(Document doc)
        {
            Data.Clear();
            Data.AddRange(CMContext.GetCollection(doc).Data);
        }
    }
}
