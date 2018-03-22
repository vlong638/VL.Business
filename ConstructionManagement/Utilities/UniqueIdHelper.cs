using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmSoft.ConstructionManagement.Utilities
{
    class UniqueIdHelper
    {
        public static string UniqueIdStr { get { return UniqueId.ToString(); } }
        public static Guid UniqueId;
        public static void PrepareUniqueId(Document doc)
        {
            var recorder = PMSoftHelper.GetRecorder(nameof(UniqueIdHelper), doc);
            string dataStr = "";
            recorder.ReadValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForSubsidenceMonitor.UniqueId, 1), ref dataStr, 40);
            if (!Guid.TryParse(dataStr,out UniqueId))
            {
                UniqueId = Guid.NewGuid();
                recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForSubsidenceMonitor.UniqueId, 1), UniqueId.ToString());
            }
        }
    }
}
