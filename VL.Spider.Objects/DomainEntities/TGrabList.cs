using System;
using System.Runtime.Serialization;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Entities
{
    public partial class TGrabList
    {
        [DataContract]
        public enum CreateGrabListResult
        {
            [EnumMember]
            Success,
            [EnumMember]
            DbOperationFailed,
            [EnumMember]
            Existed,
        }
        public CreateGrabListResult Create(DbSession session, Guid spiderId, string issueName, short orderNumber, string title, string url, string remark = "")
        {
            if (CheckExistence(session, spiderId, issueName, orderNumber))
            {
                return CreateGrabListResult.Existed;
            }
            ListItemId = Guid.NewGuid();
            SpiderId = spiderId;
            IssueName = issueName;
            OrderNumber = orderNumber;
            Title = title;
            URL = url;
            Remark = remark;
            DetailFilePath = "";
            return this.DbInsert(session) ? CreateGrabListResult.Success : CreateGrabListResult.DbOperationFailed;
        }

        private static bool CheckExistence(DbSession session, Guid spiderId, string issueName, short orderNumber)
        {
            var query = IORMProvider.GetDbQueryBuilder(session).SelectBuilder;
            query.ComponentSelect.Values.Add(new ComponentValueOfSelect("1"));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, spiderId, LocateType.Equal));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueName, issueName, LocateType.Equal));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, orderNumber, LocateType.Equal));
            var result = IORMProvider.GetQueryOperator(session).SelectAsInt<TGrabList>(session, query);
            return result!=null;
        }
    }
}
