using System.Runtime.Serialization;
using System;
using VL.Common.DAS.Objects;
using Dacai.MagicSquareAlgorithm.Objects.Enums;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;
using System.Collections.Generic;
using System.Linq;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    //public enum ECurrentValueStatus
    //{
    //    /// <summary>
    //    /// ʵʱ��,����Ч��
    //    /// </summary>
    //    Instance,
    //    /// <summary>
    //    /// ������Ч
    //    /// </summary>
    //    Available,
    //    /// <summary>
    //    /// ��ֵ
    //    /// </summary>
    //    NoValue,
    //}
    [DataContract]
    public class TMSAlgorithmSettingValue
    {
        [DataMember]
        public ESubWeightType SubWeightType { get; set; }
        [DataMember]
        public EResultType ResultType { get; set; }
    }
    public partial class TMSAlgorithmSettings
    {
        //public ECurrentValueStatus CurrentValueStatus{ set; get; }
        //public EResultType CurrentValue { set; get; }
        public bool IsMatched{ set; get; }

        public void CheckIsMatched(IEnumerable<TMSAlgorithmSettingValue> settingValues)
        {
            var settingValue = settingValues.First(c => c.SubWeightType == SubWeightType);
            IsMatched = settingValue.ResultType == ResultType;
        }
        public int CalculateOdds()
        {
            return IsMatched ? WeightValue : 0;
        }
    }
}
