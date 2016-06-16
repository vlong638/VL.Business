using System.Runtime.Serialization;

namespace Dacai.MagicSquareAlgorithm.Objects.Enums
{
    [DataContract]
    public enum ESubWeightType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 联赛级别
        /// </summary>
        [EnumMember]
        LeagueLevel,
        /// <summary>
        /// 积分排名
        /// </summary>
        [EnumMember]
        IntegrationLevel,
        /// <summary>
        /// 进攻能力
        /// </summary>
        [EnumMember]
        AttactAbility,
        /// <summary>
        /// 防守能力
        /// </summary>
        [EnumMember]
        DefenseAbility,
        /// <summary>
        /// 近期战绩
        /// </summary>
        [EnumMember]
        RecentHistory,
        /// <summary>
        /// 近六场战绩
        /// </summary>
        [EnumMember]
        RecentHistory6,
        /// <summary>
        /// 近十场战绩
        /// </summary>
        [EnumMember]
        RecentHistory10,
        /// <summary>
        /// 近三十场战绩
        /// </summary>
        [EnumMember]
        RecentHistory30,
        /// <summary>
        /// 初期赔率
        /// </summary>
        [EnumMember]
        BeginningOdds,
        /// <summary>
        /// 即时赔率
        /// </summary>
        [EnumMember]
        TemperateOdds,
        /// <summary>
        /// 最终赔率
        /// </summary>
        [EnumMember]
        FinnalOdds,
        /// <summary>
        /// 相似初赔
        /// </summary>
        [EnumMember]
        SimilarBeginningOdds,
        /// <summary>
        /// 相似终赔
        /// </summary>
        [EnumMember]
        SimilarFinnalOdds,
        /// <summary>
        /// 交易盈亏
        /// </summary>
        [EnumMember]
        BankerProfits,
    }
}
