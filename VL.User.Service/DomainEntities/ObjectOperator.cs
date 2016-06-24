using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;

namespace VL.User.Service.DomainEntities
{
    public class ObjectOperator
    {
        public Result<List<TUser>> GetAllUsers(DbSession session)
        {
            Result<List<TUser>> result = new Result<List<TUser>>();
            result.Data = new List<TUser>().DbSelect(session);
            result.ResultCode = EResultCode.Success;
            return result;
        }
    }
}
