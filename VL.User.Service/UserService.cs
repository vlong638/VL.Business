using VL.Common.Protocol.IResult;
using VL.User.Entities;
using VL.User.Service.DomainEntities;
using VL.User.Service.SubResults;
using VL.User.Service.Utilities;

namespace VL.User.Service
{

    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class UserService : IUserService
    {
        public Result<CreateUserResult> CreateUser(TUser user)
        {
            var result = Operator.CreateUser(user);
            LogHelper.LogResult(result);
            return result;
        }
    }
}
