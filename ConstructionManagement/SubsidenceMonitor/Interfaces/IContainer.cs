using System.Collections.Generic;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Interfaces
{
    public interface IContainer<T>
    {
        List<T> Datas { set; get; }
    }
}
