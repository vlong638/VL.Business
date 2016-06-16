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
            //��ȡ����
            this.FetchMSAlgorithmSettings(session);
            //��ȡԴ����
            var settingValues = MSAlgorithmSettings.Select(c => new TMSAlgorithmSettingValue() { SubWeightType = c.SubWeightType, ResultType = EResultType.None });
            //TODO�����ⲿ��Ŀ��SDK��ȡ������Դ
            //��������ʹ������Դ�������
            foreach (var msAlgorithmSetting in MSAlgorithmSettings)
            {
                msAlgorithmSetting.CheckIsMatched(settingValues);
            }
            //����ʤ��
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
