using System;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Entities
{
    public partial class TSpider
    {
        public bool Create(DbSession session, string spiderName)
        {
            //throw new NotImplementedException("存在重复的爬虫名称");
            if (CheckExistence(session, spiderName))
            {
                return false;
            }
            SpiderId = Guid.NewGuid();
            SpiderName = spiderName;
            return this.DbInsert(session);
        }

        private static bool CheckExistence(DbSession session, string spiderName)
        {
            var query = IORMProvider.GetDbQueryBuilder(session).SelectBuilder;
            query.ComponentSelect.Values.Add(new ComponentValueOfSelect("1"));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderName, spiderName, LocateType.Equal));
            var @operator = IORMProvider.GetQueryOperator(session);
            return @operator.SelectAsInt<TSpider>(session, query).HasValue;
        }


        public bool ChangeName(DbSession session, string spiderName)
        {
            if (CheckExistence(session, spiderName))
            {
                return false;
            }
            SpiderName = spiderName;
            return this.DbUpdate(session, TSpiderProperties.SpiderName);
        }
    }
}
