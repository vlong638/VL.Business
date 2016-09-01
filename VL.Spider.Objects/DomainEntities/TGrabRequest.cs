using System;
using System.Runtime.Serialization;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Objects.Entities
{
    public partial class TGrabRequest
    {
        [DataContract]
        public enum CreateGrabRequestResult
        {
            [EnumMember]
            Success,
            [EnumMember]
            DbOperationFailed,
            [EnumMember]
            Existed,
        }
        public CreateGrabRequestResult Create(DbSession session, Guid spiderId, EGrabType grabType, string issueName, string spiderName)
        {
            if (CheckExistence(session, spiderId, grabType, issueName))
            {
                return CreateGrabRequestResult.Existed;
            }
            RequestId = Guid.NewGuid();
            SpiderId = spiderId;
            GrabType = grabType;
            IssueName = issueName;
            SpiderName = spiderName;
            ProcessStatus = EProcessStatus.Ready;
            Message = "";
            return this.DbInsert(session) ? CreateGrabRequestResult.Success : CreateGrabRequestResult.DbOperationFailed;
        }
        private static bool CheckExistence(DbSession session, Guid spiderId,EGrabType grabType, string issueName)
        {
            var query = IORMProvider.GetDbQueryBuilder(session).SelectBuilder;
            query.ComponentSelect.Values.Add(new ComponentValueOfSelect("1"));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, spiderId, LocateType.Equal));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.GrabType, grabType, LocateType.Equal));
            query.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.IssueName, issueName, LocateType.Equal));
            var result = IORMProvider.GetQueryOperator(session).SelectAsInt<TGrabRequest>(session, query);
            return result != null;
        }
        public bool Settle(DbSession session, EProcessStatus processStatus,string message="")
        {
            ProcessStatus = processStatus;
            Message = message;
            return this.DbUpdate(session, TGrabRequestProperties.ProcessStatus, TGrabRequestProperties.Message);
        }
    }
}
