namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Interfaces
{
    public interface ILazyLoadData
    {
        bool IsLoad { set; get; }
        /// <summary>
        /// 0 for Node and NodeElements
        /// 1 for NodeElements Only
        /// </summary>
        /// <param name="type"></param>
        void LoadData(int type);
    }
}
