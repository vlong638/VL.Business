using System.Runtime.Serialization;
using System;
using VL.Common.DAS.Objects;
using VL.Transaction.Enums;

namespace VL.Transaction.Entities
{
    public static class TOrderEx
    {
        public static void CreateDetail(this TOrder tOrder, DbSession session, TOrderDetail orderDetail)
        {
        }
        public static void Payed(this TOrder tOrder, DbSession session, Guid userId)
        {
        }
    }
}
