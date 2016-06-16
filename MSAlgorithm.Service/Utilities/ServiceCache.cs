using Dacai.MagicSquareAlgorithm.Objects.Entities;
using Dacai.MagicSquareAlgorithm.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAlgorithm.Service.Utilities
{
    class ServiceCache
    {
        //TODO按照英超...分类对其近N场基础数据进行缓存
        List<CachedCategoriedResult> CategoriedResults = new List<CachedCategoriedResult>();



    }
    class CachedCategoriedResult
    {
        EAlgorithmSourceType SourceType { set; get; }
        List<CachedResult> MatchResults { set; get; } = new List<CachedResult>();
    }

    class CachedResult
    {
        long MatchId { set; get; }
        List<TMSAlgorithmSettingValue> SettingValues { set; get; } = new List<TMSAlgorithmSettingValue>();
    }
}
