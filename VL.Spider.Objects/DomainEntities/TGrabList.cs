using System;
using VL.Common.DAS.Objects;

namespace VL.Spider.Objects.Entities
{
    public partial class TGrabList
    {
        public bool Create(DbSession session,Guid spiderId,string issueName,short orderNumber,string title,string url,string remark="")
        {
            ListItemId = Guid.NewGuid();
            SpiderId = spiderId;
            IssueName = issueName;
            OrderNumber = orderNumber;
            Title = title;
            URL = url;
            Remark = remark;
            return this.DbInsert(session);
        }
    }
}
