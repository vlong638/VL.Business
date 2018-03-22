
namespace PMSoft.ConstructionManagementV2.DomainModel
{
    /// <summary>
    /// 报告类型
    /// </summary>
    public enum EIssueType
    {
        None = 0,
        /// <summary>
        /// 土方分块
        /// </summary>
        TFFK,
        /// <summary>
        /// 桩（墙）顶水平位移
        /// </summary>
        ZQDSPWY,
        /// <summary>
        /// 桩（墙）顶沉降
        /// </summary>
        ZQDCJ,
        /// <summary>
        /// 周边地表沉降
        /// </summary>
        ZBDBCJ,
        /// <summary>
        /// 管线沉降
        /// </summary>
        GXCJ,
        /// <summary>
        /// 砼支撑
        /// </summary>
        TZC,
        /// <summary>
        /// 钢支撑
        /// </summary>
        GZC,
        /// <summary>
        /// 水位
        /// </summary>
        SW,
        /// <summary>
        /// 侧斜
        /// </summary>
        CX,
    }
}
