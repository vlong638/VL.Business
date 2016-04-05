using System;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;
using VL.Common.Protocol.IResult;
using VL.Transaction.Entities;
using VL.Transaction.Service.IResult;
using VL.Transaction.Service.Utilities;

namespace VL.Transaction.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class TransactionService : ITransactionService
    {
        static TransactionService()
        {
            DbHelper.ConfigEntities.Load();
        }

        public Result<ESubResultCode> AddUser()
        {
            var result = new Result<ESubResultCode>();
            result.ResultCode = EResultCode.Success;
            result.SubResultCode = ESubResultCode.Local;
            return result;

            //using (DbSession session=DbHelper.GetDbSession(DatabaseName.Succinctly))
            //{
            //    TUser user = new TUser();
            //    user.UserId = Guid.NewGuid();
            //    user.Name = "Xia" + DateTime.Now.ToString("HHmmss");
            //    user.DbInsert(session);
            //}
        }
        public Result AddOrder()
        {
            return null;
            //using (DbSession session = DbHelper.GetDbSession(DatabaseName.Succinctly))
            //{
            //    var queryBuilder = IDbQueryBuilder.GetDbQueryBuilder(session);
            //    var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            //    var users = queryOperator.SelectAll<TUser>(session);
            //    var user = users.FirstOrDefault();
            //    if (user==null)
            //    {
            //        throw new NotImplementedException("无用户存在");
            //    }
            //    return user.CreateOrder(session);
            //}
        }
    }

}
