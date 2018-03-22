namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Interfaces
{
    public interface IStringBasedData
    {
        void DeserializeFromString(string str);
        string SerializeToString();
    }
}
