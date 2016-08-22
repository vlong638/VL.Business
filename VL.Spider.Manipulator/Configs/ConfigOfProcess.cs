namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 数据源-管理配置
    /// 主要负责管理器调度及输出方面的配置
    /// </summary>
    public class ConfigOfProcess
    {
        /// <summary>
        /// 最大线程数
        /// </summary>
        public int MaxConnectionNumber { set; get; } = 1;
    }
}
