using Dacai.MagicSquareAlgorithm.Objects.Enums;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public partial class TMSAlgorithm
    {
        public Result<int> CalculateOdds(DbSession session)
        {
            Result<int> result = new Result<int>();
            //获取配置
            this.FetchMSAlgorithmSettings(session);
            //获取源数据
            var settingValues = MSAlgorithmSettings.Select(c => new TMSAlgorithmSettingValue() { SubWeightType = c.SubWeightType, ResultType = EResultType.None });
            //TODO调用外部项目的SDK获取最新资源
            //根据配置使用数据源填充数据
            foreach (var msAlgorithmSetting in MSAlgorithmSettings)
            {
                msAlgorithmSetting.CheckIsMatched(settingValues);
            }
            //计算胜率
            int odds = 0;
            odds += MSAlgorithmSettings.Where(c => c.TopWeightType == ETopWeightType.JC).Sum(c => c.CalculateOdds()) * this.JCWeight;
            odds += MSAlgorithmSettings.Where(c => c.TopWeightType == ETopWeightType.DZ).Sum(c => c.CalculateOdds()) * this.DZWeight;
            odds += MSAlgorithmSettings.Where(c => c.TopWeightType == ETopWeightType.PL).Sum(c => c.CalculateOdds()) * this.PLWeight;
            //var notValueSettings = settingValues.Where(c => c.ResultType == EResultType.None);
            //foreach (var notValueSetting in notValueSettings)
            //{
            //    notValueSetting
            //}
            result.SubResultCode = odds / 100;
            return result;
        }
    }
}
