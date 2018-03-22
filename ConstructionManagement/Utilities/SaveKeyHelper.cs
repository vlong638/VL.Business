using PmSoft.ConstructionManagement.EarthWork.Entity;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using PmSoft.ConstructionManagement.SubsidenceMonitor.UI;
using System;

namespace PmSoft.ConstructionManagement.Utilities
{
    public class SaveKeyHelper
    {
        //改为Enum取值更简洁...
        public enum SaveKeyTypeForEarthWork
        {
            EarthworkBlocking,
            EarthworkBlocking_Size,

            EarthworkBlock,
            EarthworkBlock_Size,

            EarthworkBlockCPSettings,
            EarthworkBlockCPSettings_Size,

            EarthworkBlockImplementationInfo,
            EarthworkBlockImplementationInfo_Size,
        }
        //public static string GetSaveKey(SaveKeyTypeForEarthWork saveKeyType, int id)
        //{
        //    switch (saveKeyType)
        //    {
        //        case SaveKeyTypeForEarthWork.EarthworkBlocking:
        //            return nameof(EarthworkBlocking);
        //        case SaveKeyTypeForEarthWork.EarthworkBlocking_Size:
        //            return nameof(EarthworkBlocking) + "Size";
        //        case SaveKeyTypeForEarthWork.EarthworkBlock:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlock) + id;
        //        case SaveKeyTypeForEarthWork.EarthworkBlock_Size:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlock) + id + "Size";
        //        case SaveKeyTypeForEarthWork.EarthworkBlockCPSettings:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlockCPSettings) + id;
        //        case SaveKeyTypeForEarthWork.EarthworkBlockCPSettings_Size:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlockCPSettings) + id + "Size";
        //        case SaveKeyTypeForEarthWork.EarthworkBlockImplementationInfo:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlockImplementationInfo) + id;
        //        case SaveKeyTypeForEarthWork.EarthworkBlockImplementationInfo_Size:
        //            return nameof(EarthworkBlocking) + nameof(EarthworkBlockImplementationInfo) + id + "Size";
        //        default:
        //            throw new NotImplementedException("暂不支持该类型");
        //    }
        //}

        public enum SaveKeyTypeForSubsidenceMonitor
        {
            /// <summary>
            /// 项目唯一键
            /// </summary>
            UniqueId,
            /// <summary>
            /// 预警值存储
            /// </summary>
            WarnSettings,
            /// <summary>
            /// 用于图表界面的记忆功能
            /// </summary>
            ChartForm,
            /// <summary>
            /// 用于列表界面的记忆功能
            /// </summary>
            ListForm,
        }
        public static string GetSaveKey(SaveKeyTypeForSubsidenceMonitor saveKeyType, int id)
        {
            switch (saveKeyType)
            {
                case SaveKeyTypeForSubsidenceMonitor.WarnSettings:
                    return nameof(WarnSettingsForm);
                case SaveKeyTypeForSubsidenceMonitor.ChartForm:
                    return nameof(ChartForm);
                case SaveKeyTypeForSubsidenceMonitor.ListForm:
                    return nameof(ListForm);
                case SaveKeyTypeForSubsidenceMonitor.UniqueId:
                    return nameof(SaveKeyTypeForSubsidenceMonitor.UniqueId);
                default:
                    throw new NotImplementedException("暂不支持该类型");
            }
        }
    }
}
