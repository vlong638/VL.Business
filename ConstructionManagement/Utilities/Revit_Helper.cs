using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace PmSoft.ConstructionManagement.Utilities
{
    public class Revit_Helper
    {
        public static OverrideGraphicSettings GetOverrideGraphicSettings(Color color, ElementId fillPatternId, int transparency)
        {
            OverrideGraphicSettings settings = new OverrideGraphicSettings();
            settings.SetCutFillColor(color);
            settings.SetCutFillPatternId(fillPatternId);
            settings.SetCutLineColor(color);
            settings.SetCutLinePatternId(fillPatternId);
            settings.SetProjectionFillColor(color);
            settings.SetProjectionFillPatternId(fillPatternId);
            settings.SetProjectionLineColor(color);
            settings.SetProjectionLinePatternId(fillPatternId);
            settings.SetSurfaceTransparency(transparency);
            return settings;
        }
        public static void UnhideElement(View view, List<ElementId> elementIds)
        {
            List<ElementId> idToHide = new List<ElementId>();
            foreach (var elementId in elementIds)
            {
                var group = view.Document.GetElement(elementId) as Group;
                if (group != null)
                {
                    idToHide.AddRange(group.GetMemberIds());
                }
                else
                {
                    idToHide.Add(elementId);
                }
            }
            view.UnhideElements(idToHide);
            //Revit_Helper.UnhideElement(view, idToHide);
        }
        public static void ApplyOverrideGraphicSettings(View view, ElementId elementId, OverrideGraphicSettings setting)
        {
            var group = view.Document.GetElement(elementId) as Group;
            if (group != null)
            {
                foreach (var memberId in group.GetMemberIds())
                    view.SetElementOverrides(memberId, setting);
            }
            else
            {
                view.SetElementOverrides(elementId, setting);
            }
        }
    }
}
