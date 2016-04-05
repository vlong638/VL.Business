using System.Runtime.Serialization;
using System;
using VL.Common.DAS.Objects;
using VL.Transaction.Enums;

namespace VL.Transaction.Entities
{
    public static class TUserEx
    {
        public static bool CreateOrder(this TUser tUser, DbSession session)
        {
            //Order.DbInsert()
            TOrder order = new TOrder();
            order.OrderId = Guid.NewGuid();
            order.UserId = tUser.UserId;
            order.OrderStatus = EOrderStatus.None;
            order.Description = DateTime.Now.ToShortTimeString();
            return order.DbInsert(session);
        }
        public static void CreateAccount(this TUser tUser,DbSession session,TAccount tAccount)
        {
            //Account.DbInsert()
        }
        public static void CreateOrderDetail(this TUser tUser, DbSession session, Guid orderId, TOrderDetail orderDetail)
        {
            //Order.CreateDetail
        }
        public static void PayForOrder(this TUser tUser, DbSession session, Guid orderId)//content
        {
            //Order.Payed()
            //手续费处理
            //Receipt.DbInsert()
        }
    }
}
