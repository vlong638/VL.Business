using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using VL.Common.Core.Object.Subsidence;

namespace Subsidence.Business
{
    public static class TEarthworkBlockDomain
    {
        public static void DeleteEarthworkBlockElements(this TEarthworkBlock earthworkBlock, DbSession session)
        {
            var query = session.GetDbQueryBuilder().DeleteBuilder;
            query.ComponentWhere.Add(TEarthworkBlockElementProperties.IssueDateTime, earthworkBlock.IssueDateTime, LocateType.Equal);
            query.ComponentWhere.Add(TEarthworkBlockElementProperties.Id, earthworkBlock.Id, LocateType.Equal);
            var @operator = session.GetQueryOperator();
            @operator.Delete<TEarthworkBlockElement>(query);
        }

        public static void InsertEarthworkBlockElements(this TEarthworkBlock earthworkBlock, DbSession session)
        {
            List<int> elementIds = null;
            short groupId = 1;
            for (int i = 0; i < earthworkBlock.ElementIds.Count; i++)
            {
                if (i % 100 == 0)
                {
                    elementIds = new List<int>();
                }
                elementIds.Add(earthworkBlock.ElementIds[i]);
                if (i % 100 == 99 || i == earthworkBlock.ElementIds.Count - 1)
                {
                    new TEarthworkBlockElement(earthworkBlock.IssueDateTime, earthworkBlock.Id, groupId) { ElementIds = string.Join(",", elementIds) }.DbInsert(session);
                    groupId++;
                }
            }
        }
    }
}
